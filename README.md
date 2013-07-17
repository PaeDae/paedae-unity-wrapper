# PaeDae's Unity Wrapper 

(_see: [PaeDae's Unity API](http://apps.paedae.com/docs/unity)_)

## Installations

### Within your Unity project:

#### Importing PaeDaeUnity File
1. Navigate to Assets->Import Package->Custom Package
2. Navigate to the PaeDae.unitypackage and click 'Open'
3. A dialog box will pop-up notifying you of the assets being imported. Click 'Import' to complete the process

#### Compile Unity to iOS
1. File -> Build & Run
2. In "Build Setting Window", under Platform choose "iOS", and click the "Build and Run" button.
3. Once Xcode Open follow the Unity Xcode Project instructions.

### Unity on Xcode Project

#### PaeDae's Unity files in Xcode
Copy the following header and main files into the 'Classes' directory:

        - PaeDaeUnityImpl.h
        - PaeDaeUnityImpl.mm

#### PaeDae's SDK in Xcode

1. Copy the PaeDaeSDK folder into your project (url for the sdk: [PaeDae's SDK](https://github.com/PaeDae/paedae-ios-sdk)).

*Note*

You can remove the extra folders in the PaeDaeSDK, unless you're targetting certain architecture.
The bare minimum files is

        - libPaeDaeSDK.a
        - PaeDaeSDK.h

_Including any other .a files might result in unexpected errors._

2. In Classes/AppController.mm file, import the Pae Dae SDK:

`#import "PaeDaeSDK.h"`

### AdSupport.framework

Ensure AdSupport.framework is present in your Xcode project. Follow these steps to add the framework to your project:

1. Click the top-level 'Unity-iPhone' project in Xcode
2. Click your selected target (e.g. Unity-iPhone)
3. Navigate to the 'Build Phases' tab
4. Open the 'Link Binary With Libraries' pane
5. Click the + sign, select Adsupport.framework, and click 'Add'
6. SDK Interaction is handled in the PaeDaeUnityImpl.mm file
6. Initialize the SDK by supplying your gamekey string in the _InitWithKey() method. You can conveniently place your string directly in the @"" NSString definition

### Linker Flags

#### Make sure you add the following to Other Linker Flags:

    -lz
    -all_load
    -ObjC

_This is under Targets (Unity-iPhone->Build Settings)_
