# PaeDae's Unity Wrapper 

## Introduction

The PaeDae Wrapper is distributed primarily as a .unityPackage file.  
This file automatically imports the PaeDae iOS SDK and helper files to use the SDK within a Unity project.
Includes in this repo is also a sample Unity project that is used to develop the wrapper so that developers can view a sample integration.
Inside the sample Unity project is a sample script named `PaeDaeSample` that can be used as copy and paste integration for your project.

_Please note that the Unity Wrapper only supports iOS._

#### Importing PaeDaeUnity Package

1. Navigate to Assets->Import Package->Custom Package.
2. Navigate to the `PaeDae.unitypackage` and click 'Open'.
3. A dialog box will pop-up notifying you of the assets being imported. Click 'Import' to complete the process.

#### Configuring the iOS Project

1. Add AdSupport.framework under Targets->Build Phases.
2. Add the following linker flags: `-lz -all_load -ObjC`

#### Sample Unity Project

The sample Unity project includes all the files that are imported from the unity package.
It also includes a test scene named 'PaeDaeScene' that has a script attached to it named `PaeDaeSample`.
The PaeDaeSample script is just an example of how a script within your project can interact with the PaeDae SDK.

<pre>
using UnityEngine;
using System.Collections;

public class PaeDaeSample : MonoBehaviour 
{
	private string LabelMessage;
	public GUIStyle LabelStyle;
	
	private PaeDaeManager PaeDae;
	
	void Awake ()
	{
		Debug.Log ("Awake called");
		
		// Initialize the PaeDaeWrapper instance and attach it to this script's game object
		PaeDae = new PaeDaeManager(this.gameObject);
	}
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Start called");
		
		LabelMessage = "Initializing PaeDaeWrapper...";
		
		// Replace with your app's key, you only have to do this once in your app's lifecycle
		PaeDae.Init ("b00015e0-5cf7-012f-c818-12313f04f84c"); 
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
            PaeDae.ShowAd ("default.milestone");
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
</pre>
