using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

class WebViewCallbackTest : Kogarasi.WebView.IWebViewCallback
{
	Text uname = GameObject.Find("info").GetComponent<Text>();

	public void onLoadFail(string url)
	{
		Debug.Log("call onLoadFail : " + url);
		uname.text = "onLoadFail" + url;
	}

	public void onLoadFinish(string url)
	{
		Debug.Log("call onLoadFinish : " + url);
		uname.text = "onLoadFinish" + url;
	}

	public void onLoadStart( string url )
	{
		Debug.Log( "call onLoadStart : " + url );
		uname.text = "onLoadStart"+ url;
	}


}

public class WebView : MonoBehaviour
{
	// Use this for initialization
	void Start () {

	}
	public void startwebview(string url) { 
		WebViewCallbackTest m_callback = new WebViewCallbackTest();
		WebViewBehavior  webview = GetComponent<WebViewBehavior>();
		if (webview != null)
		{
			webview.openWebview(url);
			//webview.SetVisibility(true);
			webview.setCallback(m_callback);
		}
	}

	public void externalWebview(string url)
	{
		WebViewBehavior webview = GetComponent<WebViewBehavior>();
		if (webview != null)
		{
			webview.externalWebview(url);
		}
	}
}