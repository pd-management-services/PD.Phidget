namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;

    /// <summary>
    /// Implements the INotifyPropertyChanged interface and 
    /// exposes a RaisePropertyChanged method for derived 
    /// classes to raise the PropertyChange event.  The event 
    /// arguments created by this class are cached to prevent 
    /// managed heap fragmentation.
    /// </summary>
    /// <see cref="http://joshsmithonwpf.wordpress.com/2007/08/29/a-base-class-which-implements-inotifypropertychanged/"/>
    [Serializable]
    public abstract class BindableObject : INotifyPropertyChanged {
        private static readonly Dictionary<string, PropertyChangedEventArgs> EventArgCache;
        private const string ErrorMsg = "{0} is not a public property of {1}";

        /// <summary>
        /// Raised when a public property of this object is set.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        static BindableObject() {
            EventArgCache = new Dictionary<string, PropertyChangedEventArgs>();
        }

        protected void RefreshUserInterface() {
            foreach (var property in GetType().GetProperties()) {
                var attrs = Attribute.GetCustomAttributes(property);
                foreach (var attr in attrs) {
                    if (attr is NotifyPropertyChangedAttribute) {
                        RaisePropertyChanged(property.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Returns an instance of PropertyChangedEventArgs for 
        /// the specified property name.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property to create event args for.
        /// </param>		
        public static PropertyChangedEventArgs
            GetPropertyChangedEventArgs(string propertyName) {
            if (String.IsNullOrEmpty(propertyName))
                throw new ArgumentException(
                    "propertyName cannot be null or empty.");

            PropertyChangedEventArgs args;

            // Get the event args from the cache, creating them
            // and adding to the cache if necessary.
            lock (typeof(BindableObject)) {
                if (!EventArgCache.ContainsKey(propertyName)) {
                    EventArgCache.Add(
                        propertyName,
                        new PropertyChangedEventArgs(propertyName));
                }
                args = EventArgCache[propertyName];
            }

            return args;
        }

        public void SetBusyStateUntilUserInterfaceIdle() { SetBusyStateUntilUserInterfaceIdle(true); }

        //Reference: http://stackoverflow.com/questions/7346663/how-to-show-a-waitcursor-when-the-wpf-application-is-busy-databinding
        static bool isBusy;

        static void SetBusyStateUntilUserInterfaceIdle(bool busy) {
            if (busy != isBusy) {
                isBusy = busy;
                Mouse.OverrideCursor = busy ? Cursors.Wait : null;

                if (isBusy) {
                    try {
                        new DispatcherTimer(TimeSpan.FromSeconds(0), DispatcherPriority.ApplicationIdle, DispatcherTimerTick, Application.Current.Dispatcher);
                    } catch { } //empty catch is for when calling SetBusyStateUntilUserInterfaceIdle occurs during tests.
                }
            }
        }

        static void DispatcherTimerTick(object sender, EventArgs e) {
            var dispatcherTimer = sender as DispatcherTimer;
            if (dispatcherTimer != null) {
                SetBusyStateUntilUserInterfaceIdle(false);
                dispatcherTimer.Stop();
            }
        }

        /// <summary>
        /// Derived classes can override this method to
        /// execute logic after a property is set. The 
        /// base implementation does nothing.
        /// </summary>
        /// <param name="propertyName">
        /// The property which was changed.
        /// </param>
        protected virtual void AfterPropertyChanged(string propertyName) { }

        /// <summary>
        /// Attempts to raise the PropertyChanged event, and 
        /// invokes the virtual AfterPropertyChanged method, 
        /// regardless of whether the event was raised or not.
        /// </summary>
        /// <param name="propertyName">
        /// The property which was changed.
        /// </param>
        protected virtual void RaisePropertyChanged(params string[] propertyName) {
            foreach (var property in propertyName) {
                VerifyProperty(property);

                var handler = PropertyChanged;
                if (handler != null) {
                    // Raise the PropertyChanged event.
                    handler(this, GetPropertyChangedEventArgs(property));
                }

                AfterPropertyChanged(property);
            }
        }

        //Reference: http://www.clr-namespace.com/post/MagicStringInRaisePropertyChanged.aspx
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion) {
            var propertyName = ExtractPropertyName(propertyExpresssion);
            RaisePropertyChanged(propertyName);
        }

        private string ExtractPropertyName<T>(Expression<Func<T>> propertyExpresssion) {
            if (propertyExpresssion == null) {
                throw new ArgumentNullException("propertyExpresssion");
            }

            var memberExpression = propertyExpresssion.Body as MemberExpression;
            if (memberExpression == null) {
                throw new ArgumentException("The expression is not a member access expression.", "property" + "Expression");
            }

            var property = memberExpression.Member as PropertyInfo;
            if (property == null) {
                throw new ArgumentException("The member access expression does not access a property.", "property" + "Expression");
            }

            if (!property.DeclaringType.IsAssignableFrom(GetType())) {
                throw new ArgumentException("The referenced property belongs to a different type.", "property" + "Expression");
            }

            var getMethod = property.GetGetMethod(true);
            if (getMethod == null) {
                // this shouldn't happen - the expression would reject the property before reaching this far
                throw new ArgumentException("The referenced property does not have a get method.", "property" + "Expression");
            }

            if (getMethod.IsStatic) {
                throw new ArgumentException("The referenced property is a static property.", "property" + "Expression");
            }

            return memberExpression.Member.Name;
        }

        [Conditional("DEBUG")]
        private void VerifyProperty(string propertyName) {
            var type = GetType();

            // Look for a public property with the specified name.
            var propInfo = type.GetProperty(propertyName);

            if (propInfo != null) return;
            // The property could not be found,
            // so alert the developer of the problem.

            var msg = string.Format(
                ErrorMsg,
                propertyName,
                type.FullName);

            Debug.Fail(msg);
        }
    }
}
