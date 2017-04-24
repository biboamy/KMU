using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuControl : MonoBehaviour {

	public void leaveGame()
	{
		Application.Quit();
	}

	public void aboutUs(string url)
	{
		WebViewBehavior webview = GetComponent<WebViewBehavior>();
		if (webview != null)
		{
			webview.externalWebview(url);
		}
	}
}
