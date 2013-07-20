/* PaeDae Unity Wrapper - v1.0.0
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

public sealed class PaeDaeWrapper : MonoBehaviour 
{
	private static readonly PaeDaeWrapper instance = new PaeDaeWrapper();
	
	public string gameObjectName;
	
	// External function declarations implemented in C
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperInit (string key, string gameObjectName);
	
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperShowAd (string zoneId, string gameObjectName);	

	// Instantiate a singleton instance of the PaeDae Unity Wrapper 
	public static PaeDaeWrapper Instance 
	{
		get 
		{
	        return instance;
		}
	}
	
	// Public API methods
	public void Init (MonoBehaviour script, string appKey) 
	{
	    if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			_PaeDaeWrapperInit (appKey, script.gameObject.name);
		}
		else
		{
			script.SendMessage("PaeDaeInitializeFailed");
		}
	}
	
	public void ShowAd (MonoBehaviour script, string zoneId) 
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			_PaeDaeWrapperShowAd (zoneId, script.gameObject.name);
		}
		else
		{
		    script.SendMessage("PaeDaeAdUnavailable");
		}
	}
}
