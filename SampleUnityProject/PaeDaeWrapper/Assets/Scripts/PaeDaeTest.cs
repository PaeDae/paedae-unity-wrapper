using UnityEngine;
using System.Collections;

public class PaeDaeTest : MonoBehaviour 
{
	private string LabelMessage;
	
	void Awake ()
	{
		Debug.Log ("Awake called");
	}
	
	// Use this for initialization
	void Start () 
	{
		LabelMessage = "Initializing PaeDaeWrapper...";
		
		PaeDaeWrapper.Instance.onInitialized += onPaeDaeInitialized;	
		PaeDaeWrapper.Instance.onOnInitializeFailed += onPaeDaeInitializeFailed;
		PaeDaeWrapper.Instance.onAdWillDisplay += onAdWillDisplay;
		PaeDaeWrapper.Instance.onAdWillUnload += onAdWillUnload;
		PaeDaeWrapper.Instance.onAdUnavailable += onAdUnavailable;
		
		PaeDaeWrapper.Instance.Init ("b00015e0-5cf7-012f-c818-12313f04f84c");    //replace with your app's key
		
		Debug.Log ("Scene started");
	}
	
	// Update is called once per frame
	void Update () 
	{
	    
	}
	
	void OnGUI () 
	{
        GUI.Label(new Rect(10, 10, 500, 20), LabelMessage);
		
		Event Mouse = Event.current;
        if (Mouse.clickCount == 2)
        {
            PaeDaeWrapper.Instance.ShowAd ("default.milestone");
        }
    }
	
	// PaeDaeWrapper init event handlers
	void onPaeDaeInitialized ()
	{
	    string message = "PaeDaeWrapper has loaded!";
		Debug.Log (message);
	    LabelMessage = message;
	}
	
	void onPaeDaeInitializeFailed ()
	{
		string message = "PaeDaeWrapper failed to load";
		Debug.Log (message);
	    LabelMessage = message;
	}
	
	// PaeDaeWrapper ShowAd event handlers
	void onAdWillDisplay ()
	{
	    string message = "PaeDaeWrapper: ad unit has been shown";
		Debug.Log (message);
		LabelMessage = message;
	}
	
	void onAdWillUnload ()
	{
		string message = "PaeDaeWrapper: ad unit has been dismissed";
		Debug.Log (message);
		LabelMessage = message;
	}
	
	void onAdUnavailable ()
	{
		string message = "PaeDaeWrapper: no ad available";
		Debug.Log (message);
		LabelMessage = message;
	}
}
