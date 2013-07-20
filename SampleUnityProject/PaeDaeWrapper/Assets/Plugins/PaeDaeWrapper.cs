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
	public event onInitializedEvent onInitialized;
	
	public delegate void onInitializeFailedEvent();
	public event onInitializeFailedEvent onOnInitializeFailed;
	
	public delegate void onAdWillDisplayEvent();
	public event onAdWillDisplayEvent onAdWillDisplay;
	
	public delegate void onAdWillUnloadEvent();
	public event onAdWillUnloadEvent onAdWillUnload;
	
	public delegate void onAdUnavailableEvent();
	public event onAdUnavailableEvent onAdUnavailable;
	
	
	/*
	 * External function declarations implemented in C
	 */
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperInit ();
	
	[DllImport ("__Internal")]
	private static extern void _PaeDaeWrapperShowAd ();	

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
			_PaeDaeWrapperInit();
		}
		else
		{
		    instance.onOnInitializeFailed();
		}
	}
	
	public void ShowAd() 
	{
		if (Application.platform != RuntimePlatform.IPhonePlayer) 
		{
			_PaeDaeWrapperShowAd();
		}
		else
		{
		    instance.onAdUnavailable();
		}
	}
	
	// PaeDae Init Delegate unity messages from C
	public static void Initialized()
	{
		instance.onInitialized();
	}
	
	public static void InitializeFailed()
	{
		instance.onOnInitializeFailed();
	}
	
	// PaeDae Ad Delegate unity messages from 
	public static void AdWillDisplay() 
	{
		instance.onAdWillDisplay();
	}
	
	public static void AdWillUnload()
	{
		instance.onAdWillUnload();
	}
	
	public static void AdUnavailable()
	{
		instance.onAdUnavailable();
	}
}
