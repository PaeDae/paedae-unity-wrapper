/* PaeDae Unity Wrapper - v1.0.0
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
	
	public delegate void onInitializedEvent();
	public delegate void onInitializeFailedEvent();
	public delegate void onAdWillDisplayEvent();
	public delegate void onAdWillUnloadEvent();
	public delegate void onAdUnavailableEvent();
	
	public event onInitializedEvent onInitialized = null;
	public event onInitializeFailedEvent onOnInitializeFailed = null;
	public event onAdWillDisplayEvent onAdWillDisplay = null;
	public event onAdWillUnloadEvent onAdWillUnload = null;
	public event onAdUnavailableEvent onAdUnavailable = null;
	
	// Instantiate a singleton instance of the PaeDae Unity Wrapper 
	public static PaeDaeWrapper Instance 
	{
		get 
		{
	        return instance;
		}
	}
	
	// Public API methods
	public void Init (string key) 
	{
	    if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			_PaeDaeWrapperInit (key);
		}
		else
		{
		    if (instance.onOnInitializeFailed != null) instance.onOnInitializeFailed ();
		}
	}
	
	public void ShowAd (string zoneId) 
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			_PaeDaeWrapperShowAd (zoneId);
		}
		else
		{
		    if (instance.onAdUnavailable != null) instance.onAdUnavailable ();
		}
	}
	
	// PaeDae Init Delegate unity messages from C
	public static void Initialized ()
	{
		if (instance.onInitialized != null) instance.onInitialized ();
	}
	
	public static void InitializeFailed ()
	{
		if (instance.onOnInitializeFailed != null) instance.onOnInitializeFailed ();
	}
	
	// PaeDae Ad Delegate unity messages from 
	public static void AdWillDisplay () 
	{
		if (instance.onAdWillDisplay != null) instance.onAdWillDisplay ();
	}
	
	public static void AdWillUnload ()
	{
		if (instance.onAdWillUnload != null) instance.onAdWillUnload ();
	}
	
	public static void AdUnavailable ()
	{
		if (instance.onAdUnavailable != null) instance.onAdUnavailable ();
	}
	
	// External function declarations implemented in C
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperInit (string key);
	
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperShowAd (string zoneId);
}
