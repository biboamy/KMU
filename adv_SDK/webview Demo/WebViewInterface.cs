using UnityEngine;

namespace Kogarasi.WebView
{
	public interface IWebView
	{

		void Init(string url,string name);
		void Term();

		void SetMargins(int left, int top, int right, int bottom);
		void SetVisibility(bool state);

		void LoadURL(string url);

		void EvaluateJS(string js);

		void externalWebview(string url);
	}

	public interface IWebViewCallback
	{
		void onLoadStart(string url);
		void onLoadFinish(string url);
		void onLoadFail(string url);
	}
}