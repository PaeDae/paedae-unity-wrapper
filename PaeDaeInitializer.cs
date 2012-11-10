// Unity requires derivation from the MonoBehaviour class explicitly when using C#
// This initializer allows you to easily integrate PaeDae initialization within the Unity editor.
// Implement the PaeDae SDK by attaching this code to a GameObject and drop that object into your scene.

using UnityEngine;

public class PaeDaeInitializer : MonoBehaviour {
  #region Public Developer Arguments

    public string gameKey = "Enter Game Key Here";
    // public Dictionary<string, string> playerInfo = new Dictionary<string, string>();

  #endregion

 #region MonoBehaviour 

  void Awake() {
    PaeDae.Initialize(gameKey);
  }

  // Do we need to setup behavior to end the PaeDae session when app enters a closing state?
  // void OnApplicationPause(bool pause) {
  //   if (pause)
  //     PaeDae.TerminateSession();
  //   else
  //     PaeDae.BeginSession();
  // }

 #endregion 

}