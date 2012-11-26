//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

using UnityEngine;
using System.Runtime.InteropServices;

public class PaeDaeUnity {

	/* Interface to native implementation */

	/* Private Methods */

	[DllImport ("__Internal")]
	private static extern void _ShowPrizeWithOptionsAndDelegate ();

	[DllImport ("__Internal")]
	private static extern void _UpdatePlayerInfo ();

	[DllImport ("__Internal")]
	private static extern void _InitWithKey ();
	/* Public Methods */

	// Show Prize Methods

	public static void ShowPrizeWithOptionsAndDelegate()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
			_ShowPrizeWithOptionsAndDelegate();
	}

	public static void UpdatePlayerInfo()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
			_UpdatePlayerInfo();
	}

	public static void InitWithKey()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
			_InitWithKey();
	}

	// Callbacks

	public static void Initialized (string callBack)
	{
		// Handle callback here
	}

	public static void InitializationFailed (string callBack)
	{
		// Handle callback here
	}

	public static void PrizeUnloaded (string callBack)
	{
		// Handle callback here
	}

	public static void PrizeWillUnload (string callBack)
	{
		// Handle callback here
	}

	public static void PrizeWillDisplay (string callBack)
	{
		// Handle callback here
	}
}