paedae-unity-wrapper
====================

PaeDae's Unity Wrapper

See: http://apps.paedae.com/docs/unity

Installations
Within your Unity project:
Navigate to Assets->Import Package->Custom Package
Navigate to the PaeDae.unitypackage and click 'Open'
A dialog box will pop-up notifying you of the assets being imported. Click 'Import' to complete the process

File -> Build & Run
In "Build Setting Window", under Platform choose "iOS", and click the "Build and Run" button.

Once Xcode Open follow the Unity Xcode Project instructions.

Unity Xcode Project

Copy the following header and main files into the 'Classes' directory: 
	- PaeDaeUnityImpl.h 
	- PaeDaeUnityImpl.mm

Copy the PaeDaeSDK folder into your project (url for the sdk: https://github.com/PaeDae/paedae-ios-sdk).

You can remove the extra folders in the PaeDaeSDK, unless you're targetting certain architecture. 
The bare minimum files is 
	- libPaeDaeSDK.a 
	- PaeDaeSDK.h 

Including any other .a files might result in unexpected errors. 

In Classes/AppController.mm file, import the Pae Dae SDK:
\#import "PaeDaeSDK.h"

Ensure AdSupport.framework is present in your Xcode project. Follow these steps to add the framework to your project:

Click the top-level 'Unity-iPhone' project in Xcode
Click your selected target (e.g. Unity-iPhone)
Navigate to the 'Build Phases' tab
Open the 'Link Binary With Libraries' pane
Click the + sign, select Adsupport.framework, and click 'Add'
SDK Interaction is handled in the PaeDaeUnityImpl.mm file
Initialize the SDK by supplying your gamekey string in the _InitWithKey() method. You can conveniently place your string directly in the @"" NSString definition

Linker Flags:

Make sure you add the following to Other Linker Flags:
-lz
-all_load
-ObjC

This is under Targets (Unity-iPhone->Build Settings)

