using UnityEngine;
using System.Collections;
using System;

#if UNITY_ANDROID

namespace Kogarasi.WebView
{
	public class WebViewAndroid : IWebView
	{

		AndroidJavaObject webView = null;
		string inputString = "";


		public void Init(string url, string name)
		{
			webView = new AndroidJavaObject("com.example.mylibrary.webview.WebViewPlugin");
			SafeCall("StartWebView", url,name);
		}
		public void Term()
		{
			SafeCall("Destroy");
		}

		public void SetMargins(int left, int top, int right, int bottom)
		{
			SafeCall("SetMargins", left, top, right, bottom);
		}

		public void SetVisibility(bool state)
		{
			SafeCall("SetVisibility", state);
		}

		public void LoadURL(string url)
		{
			SafeCall("LoadURL", url);
		}

		public void EvaluateJS(string js)
		{
			SafeCall("LoadURL", "javascript:" + js);
		}

		private void SafeCall(string method, params object[] args)
		{
			if (webView != null)
			{
				webView.Call(method, args);
			}
			else
			{
				Debug.LogError("webview is not created. you check is a call 'Init' method");
			}
		}

		public void externalWebview(string url)
		{
			Application.OpenURL(url);
		}

	
	}
}

#endif