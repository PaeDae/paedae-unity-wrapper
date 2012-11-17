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
	// Delegates
	
	public static void UnityCallback (string textString)
	{
		Debug.Log(textString);
	}
}