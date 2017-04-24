using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using RenderHeads.Media.AVProVideo;

public class subVideo : MonoBehaviour
{

	private MediaPlayer _mediaPlayer;
	public GameObject video;
	private bool subtitle = true;
	private bool loop = false;
	public bool auto_start = false;
	//設定影片結束事件
	[SerializeField]
	public UnityEvent movie_end;

	// Use this for initialization
	void Start()
	{
		//影片初始化
		_mediaPlayer = video.GetComponent<MediaPlayer>();
		if (_mediaPlayer)
			//加入影片事件監聽
			_mediaPlayer.Events.AddListener(OnVideoEvent);
	}
	// 設定影片監聽事件
	public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
	{
		switch (et)
		{
			case MediaPlayerEvent.EventType.ReadyToPlay:
				Debug.Log("ReadyToPlay: " + et.ToString());
				if (auto_start)
				{
					playvideo();
					auto_start = false;
				}

				break;
			case MediaPlayerEvent.EventType.Started:
				Debug.Log("Started: " + et.ToString());
				if (subtitle)
				{
					textGuide.audioSource = _mediaPlayer;
					textGuide.startTextGuide = true;

				}
				break;

			case MediaPlayerEvent.EventType.FinishedPlaying:
				Debug.Log("FinishedPlaying: " + et.ToString());

				if (loop)
					StartCoroutine(waitingplay());
				else
					stopvideo();
				movieEnd();
				break;

		}

	}
	IEnumerator waitingplay()
	{
		float current = _mediaPlayer.Control.GetCurrentTimeMs();
		Debug.Log("waitingplay+++ " + current);
		do
		{
			bool _wasPlayingOnScrub = _mediaPlayer.Control.IsPlaying();
			if (!_wasPlayingOnScrub)
			{
				stopvideo();
				playvideo();
				yield return null;
			}
			else
				yield return new WaitForSeconds(.5f);
		} while (_mediaPlayer.Control.IsPlaying());

		Debug.Log("IsFinished+++ " + _mediaPlayer.Control.IsFinished());


	}

	// Update is called once per fram
	void Update()
	{

	}

	//撥放事件
	public void playvideo()
	{
		Debug.Log("play");
		_mediaPlayer.Play();
		Debug.Log("play");
		if (subtitle)
		{
			textGuide.audioSource = _mediaPlayer;
			textGuide.startTextGuide = true;
		}

	}
	//停止事件
	public void stopvideo()
	{
		_mediaPlayer.Rewind(true);

		if (subtitle)
		{
		//	textGuide.audioSource = _mediaPlayer;
			textGuide.startTextGuide = false;
		
		}
	}
	//暫停事件
	public void pausevideo()
	{
		_mediaPlayer.Pause();
	}
	//撥放結束事件
	private void movieEnd()
	{
		movie_end.Invoke();
	}
	//取得是否撥放中
	public bool isplaying()
	{
		if (_mediaPlayer.Control.IsPlaying())
			return true;
		else
			return false;

	}

}