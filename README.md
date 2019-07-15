# PD.Phidget

This repository is an open source replication of the [Phidget Control Panel](https://www.phidgets.com/docs/Phidget_Control_Panel) written in C#, using [Windows Presentation Foundation (WPF)](https://docs.microsoft.com/en-us/dotnet/framework/wpf/getting-started/introduction-to-wpf-in-vs). It is intended to be a launch point for new developers to get a better understanding of how to use the [Phidget API](https://www.phidgets.com/?view=api) and to become productive with their own projects more quickly. This re-engineering was conducted [with gracious permission](https://www.phidgets.com/phorum/viewtopic.php?f=22&t=9486&sid=41ab463090804f58c7616fcae30fd5c1) by [Phidgets.com](https://www.phidgets.com). Lastly, I would like to thank [PD Management & Services Inc.](https://www.pdgroup.com/Companies) for granting permission to release this code to open source and support the community.


# TODO
There are a number of items that have yet to be implemented in this sample. Here is a list of some of the outstanding items:

* Options Menu - The values in the Options menu have not been implemented.

 * Logging - Logging that is native to the original application has not been implemented.

* Main Screen Footer - Link to API documentation - The original application contains a control in the bottom right that links the user to the related API documentation on the Phidgets website.

* Network Phidgets Tab - MAC Address, Version, and Firmware numbers haven't been retrieved. Also, there is some logic used in the original application that must be in place here that filters out certain servers as this application picks up all and does no filtering and, subsequently, has additional connected servers listed if they are available and have network discovery turned on.

* Network Server Tab - None of the functionality of this tab has been implemented.

* Handling of Additional Phidget Types - We have only implemented the subset of phidgets that we plan to use for our own purposes and those represented in the default Phidget Control Panel application.

* Firmware Upgrade - We have not implemented firmware upgrading of the phidgets listed in the tree.

* Dictionary Maintenance Screen - The Open Connections, Open Channels, and Channel Connections grids have not been implemented.

* More elegant tree-building - It is unclear how the original application assembled the tree and its leaves. Because of this, it was assumed that, because the alert of an attached device occurs in the same order every time, that this is how to assemble the tree. We decided on a chain of command pattern to assemble tree nodes and use the rules of addressing to determine whether one item in the tree belongs to another. There is likely a more elegant method to assemble this tree structure.

Pull requests are welcomed.

# License
This repository is licensed with the [MIT](https://github.com/pd-management-services/PD.Phidget/blob/master/LICENSE) license.