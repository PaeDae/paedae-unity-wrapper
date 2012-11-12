using UnityEngine;
using System;

public class PaeDaeListener : MonoBehaviour {
  #region Private Vars
    private static PaeDaeInterface callBackHandler = null;
  #endregion

  #region MonoBehaviour
    void Awake() {
      // Instantiate the handler
      callBackHandler = (PaeDaeInterface)GameObject.Find("PaeDaeHandler").GetComponent("PaeDaeInterface");
    }
  #endregion

  #region Native Callbacks
    // Handle Initialization
    private void OnPaeDaeInitialization(string gameKey) {
      callBackHandler.OnPaeDaeInitialization(gameKey);
    }
  #endregion
}