// First stab at creating a wrapper/bridge between Unity and our SDKs.
// NOTE: Regions organize code structure in an outline hierarchy in VisualStudio

// Call Unity and service interoperability modules
using UnityEngine;
using System.Runtime.InteropServices;

public static class PaeDae {

  #region Platform Support
    private static readonly bool isSupportedPaedaePlatform    
  #endregion

  #region PaeDae Constructor
    static PaeDae() {
      // iOS only until we have our Android SDK finalized
      isSupportedPaedaePlatform = (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android);
    }
  #endregion


  #region Required iOSDLL Methods
    #if UNITY_IPHONE
      // DRY up obligatory DLL name
      private const string iOSDLLName = "__Internal";
      
      // Statically link the execs for iOS
      // This is how we call our methods!
      // [DllImport (iosDLLName)] private static extern void _SomeFunction();
      // [DllImport (iosDLLName)] private static extern bool _SomeOtherFunction();

      // PaeDae Initialization
      [DllImport (iosDLLName)] private static extern void _InitWithKey(string gameKey);
      [DllImport (iosDLLName)] private static extern void _InitWithKeyAndPlayerInfo(string gameKey, dictionary playerInfo);
      [DllImport (iosDLLName)] private static extern void _InitWithKeyAndDelegate(string gameKey, object delegate);
      [DllImport (iosDLLName)] private static extern void _InitWithKeyAndPlayerInfoAndDelegate(string gameKey, dictionary playerInfo, object delegate);
      
      // Show Prize
      [DllImport (iosDLLName)] private static extern void _ShowPrize();
      [DllImport (iosDLLName)] private static extern void _ShowPrizeWithOptions(dicitonary optionsDictionary);
      [DllImport (iosDLLName)] private static extern void _ShowPrizeWithDelegate(object delegate);
      [DllImport (iosDLLName)] private static extern void _ShowPrizeWithOptionsAndDelegate(dictionary optionsDictionary, object delegate);
      
      // Update Player Information
      [DllImport (iosDLLName)] private static extern void _updatePlayerInfo(dictionary playerInfo);
      
    #endif
  #endregion

  // #region Android Setup
  //   #if UNITY_ANDROID
  //     private static readonly AndroidJavaClass KiipInterface = new AndroidJavaClass("me.PaeDae.unity.PaeDaeInterface");
  //     
  //     private static AndroidJavaObject CurrentActivity() {
  //       AndroidJavaClass UnityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
  //       AndroidJavaObject activity = UnityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
  //       return activity;
  //     }
  //   #endif
  // #endregion

  #region PaeDae Public Interace
    // Initialization
    public static void Initialize(string gameKey) {
      if (isSupportedPaeDaePlatform) {
        #if UNITY_IPHONE
          _InitWithKey(gameKey)
        // #elif UNITY_ANDROID
         // Initialize Android
        #endif
      }
    } 
  #endregion
}