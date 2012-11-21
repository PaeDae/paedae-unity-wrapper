Implementing the PaeDae SDK into UnityiOS


Unity

1. Double-click the PaeDae.unitypackage to install the PaeDae plugin into your Assets/Plugins directory

Unity Xcode Project

1. Copy the following header and main files into the 'Classes' directory: PaeDaeSharedPrizeDelegate, PaeDaeSharedInitDelegate, and PaeDaeUnityImpl

2. Copy the PaeDaePrizeSDK folder into your project

3. Ensure AdSupport.framework is present in your Xcode project. Follow these steps to add the framework to your project:
	- Click the top-level 'Unity-iPhone' project in Xcode
	- Click your selected target
	- Navigate to the 'Build Phases' tab
	- Open the 'Link Binary With Libraries' pane
	- Click the + sign, select Adsupport.framework, and click 'Add'

4. SDK Interaction is handled in the PaeDaeUnityImpl.mm file
	- Initialize the SDK by supplying your gamekey string in the _InitWithKey() method. You can conveniently place your string directly in the @"" NSString definition

5. Delegate methods are handled respectively in PaeDaeSharedPrizeDelegate.m and PaeDaeSharedInitDelegate.m. Invoke the UnitySendMessage method to target your Unity GameObjects with specific callbacks. Consult the Unity documentation for more information ("Calling C# / JavaScript back from native code"): http://docs.unity3d.com/Documentation/Manual/PluginsForIOS.html  