using UnityEngine;
using System.Collections;

public class PaeDaeSample : MonoBehaviour 
{
	private string LabelMessage;
	public GUIStyle LabelStyle;
	
	void Awake ()
	{
		
	}
	
	// Use this for initialization
	void Start () 
	{
		LabelMessage = "Initializing PaeDaeWrapper...";
		
		//replace with your app's key
		PaeDaeWrapper.Instance.Init ("b00015e0-5cf7-012f-c818-12313f04f84c", this.gameObject); 
		
		Debug.Log ("Scene started");
	}
	
	// Update is called once per frame
	void Update () 
	{
	    
	}
	
	void OnGUI () 
	{
        GUI.Label(new Rect(10, 10, 500, 250), LabelMessage, LabelStyle);
		
		Event Mouse = Event.current;
        if (Mouse.clickCount == 2)
        {
            PaeDaeWrapper.Instance.ShowAd ("default.milestone", this.gameObject);
        }
    }
	
	// PaeDaeWrapper init event handlers
	void PaeDaeInitialized ()
	{
	    string message = "PaeDaeWrapper loaded - double click to show";
		Debug.Log (message);
	    LabelMessage = message;
	}
	
	void PaeDaeInitializeFailed ()
	{
		string message = "PaeDaeWrapper failed to load";
		Debug.Log (message);
	    LabelMessage = message;
	}
	
	// PaeDaeWrapper ShowAd event handlers
	void PaeDaeAdWillDisplay ()
	{
	    string message = "PaeDaeWrapper: ad unit has been shown";
		Debug.Log (message);
		LabelMessage = message;
	}
	
	void PaeDaeAdUnloaded ()
	{
		string message = "PaeDaeWrapper: ad unit has been dismissed";
		Debug.Log (message);
		LabelMessage = message;
	}
	
	void PaeDaeAdUnavailable ()
	{
		string message = "PaeDaeWrapper: no ad available";
		Debug.Log (message);
		LabelMessage = message;
	}
}
