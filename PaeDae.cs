// First stab at creating a wrapper/bridge between Unity and our SDKs.
// Regions 




// Call Unity and service interoperability modules
using UnityEngine;
using System.Runtime.InteropServices;

public static class PaeDae {

  #region Platform Support
    private static readonly bool isSupportedPaedaePlatform    
  #endregion

  #region PaeDae Constructor
    static PaeDae(){
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
      [DllImport (iosDLLName)] private static extern void _someFunction();
      [DllImport (iosDLLName)] private static extern bool _someOtherFunction();
      
    #endif
  #endregion
}