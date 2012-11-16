using UnityEngine;
using System.Runtime.InteropServices;

public class PaeDaeUnity {

	/* Interface to native implementation */
	
	[DllImport ("__Internal")]
	private static extern void _ShowPrize ();
	
	/* Public interface for use inside C# / JS code */
	
	// Starts lookup for some bonjour registered service inside specified domain
	public static void ShowPrize()
	{
		// Call plugin only when running on real device
		if (Application.platform != RuntimePlatform.OSXEditor)
			_ShowPrize();
	}
}