/* PaeDae Unity Wrapper - v1.0.2
 * iOS - v1.0.4
 * 
 * Copyright (c) 2012 PaeDae Inc. All rights reserved.
 * Greg Morrison, Anthony Doan, Miguel Morales
 * 
 * Contact: developers@paedae.com
 * 
 * Thanks to:
 * http://msdn.microsoft.com/en-us/library/ff650316.aspx
 */

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class PaeDaeWrapper : MonoBehaviour 
{
	private GameObject script;
	
	// External function declarations implemented in C
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperInit (string key, string objectName);
	
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperShowAd (string milestoneId, string objectName);	
	
	public PaeDaeWrapper (GameObject caller)
	{
	    script = caller;
	}
	
	// Public API methods
	public void Init (string appKey) 
	{
	    if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			_PaeDaeWrapperInit (appKey, script.name);
		}
		else
		{
			script.SendMessage("PaeDaeInitializeFailed");
		}
	}
	
	public void ShowAd (string milestoneId) 
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			_PaeDaeWrapperShowAd (milestoneId, script.name);
		}
		else
		{
		    script.SendMessage("PaeDaeAdUnavailable");
		}
	}
}
