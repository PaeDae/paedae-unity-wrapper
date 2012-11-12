using UnityEngine;

public class PaeDaeHandler : MonoBeahviour, PaeDaeInterface {
  #region PaeDae Handling
    // Handle Initialization
    public void OnPaeDaeInitialization(string gameKey) {
      PaeDae.Initialize();
    }
  #endregion
}