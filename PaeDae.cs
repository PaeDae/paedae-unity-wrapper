//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

using UnityEngine;
using System.Runtime.InteropServices;

public class PaeDaeUnity {

	/* Interface to native implementation */

	/* Private Methods */

	[DllImport ("__Internal")]
	private static extern void _ShowAd ();	

	[DllImport ("__Internal")]
	private static extern void _Init ();
	/* Public Methods */

	// Show Ad Methods
	
	public static void ShowAd()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
			_ShowAd();
	}

	public static void Init()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
			_Init();
	}

}