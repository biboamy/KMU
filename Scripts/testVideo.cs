using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using cqplayart.amy.RWControl;
using Vuforia;

public class testVideo : MonoBehaviour {

	subVideo subvideo;
	myRWControl control;
	public int nowPlaying;
	MediaPlayer script;
	ObjectTracker tracker;

	bool infoClick = false;
	bool replayAppear = false;
	bool restart = false;

	static string testSecond = "testSecond";
	static string testTrack = "firstTrack";

	void Start()
	{
		script = GameObject.Find("MediaPlayer").GetComponent<MediaPlayer>();
		script.SetDebugGuiEnabled(false);
		subvideo = GameObject.Find("videoObject").GetComponent<subVideo>();
		tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
		control = new RWInterfaceBehavior();
	}

	void OnApplicationQuit()
	{
		Debug.Log("quit");
		control.deleteFile(testTrack);
	}

	void OnDisable()
	{
		Debug.Log("disable");
		control.deleteFile(testTrack);
	}

	void OnApplicationPause()
	{
		Debug.Log("pause");
		control.deleteFile(testTrack);
	}

	public void setSubtitleVisible(bool value)
	{
		if(GameObject.Find("subtitlecontrol") != null)
			GameObject.Find("subtitlecontrol").SetActive(value);
	}

	public void setARvisible(bool value)
	{
		if (GameObject.Find("05AR") != null)
			GameObject.Find("05AR").SetActive(value);
	}

	public void replayTouch()
	{
		subvideo.playvideo();
		GameObject.Find("V btn").SetActive(false);
		replayAppear = false;
	}

	public void clickBack()
	{
		control = new RWInterfaceBehavior();
		if (control.readfile(testTrack) != null)
		{
			subvideo.stopvideo();
			setSubtitleVisible(false);
		}

		control.deleteFile(testTrack);

		foreach (DataSet data in tracker.GetDataSets())
			tracker.DeactivateDataSet(data);

		if (GameObject.Find("nav_Q") != null)
			GameObject.Find("nav_Q").SetActive(false);

		AdvUIM.uimNaviBar.InstanceManager.ChangeNaviBarTitle(0);

		QRcodeTrigger trigger = new QRcodeTrigger();
		trigger.reset();
	}

	public void videoStart()
	{
		if (control.readfile(testTrack) == null)
		{
			control.writefile("firstTrack", "track");
			tracker.Start();

			//set subtitle text
			GameObject.Find("textObject").GetComponent<textGuide>().m_setsub(nowPlaying - 1);

			script.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, "my3g2/guide" + nowPlaying.ToString() + ".mp4", true);

			Transform[] trs = GameObject.Find("UIM").GetComponent<Transform>().GetChild(0).gameObject.GetComponentsInChildren<Transform>(true);
			foreach (Transform child in trs)
			{
				if (child.name != "V btn")
					child.gameObject.SetActive(true);
				if (child.name == "V btn")
					child.gameObject.SetActive(false);
			}
		}
		else
		{
			if (!infoClick)
			{
				//set subtitle text
				GameObject.Find("textObject").GetComponent<textGuide>().m_setsub(nowPlaying - 1);

				script.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, "my3g2/guide" + nowPlaying.ToString() + ".mp4", true);

				if (GameObject.Find("V btn") != null)
				{
					GameObject.Find("V btn").SetActive(false);
				}
			}
			else if(restart)
			{
				tracker.Start();
				if (!replayAppear)
				{
					subvideo.playvideo();
				}
				infoClick = false;
			}
		}
	}

	public void showReplay()
	{
		script.m_AutoStart = false;
		script.m_AutoOpen = false;

		Transform[] trs = GameObject.Find("UIM").GetComponent<Transform>().GetChild(0).gameObject.GetComponentsInChildren<Transform>(true);
		foreach (Transform child in trs)
		{
			if (child.name == "V btn")
				child.gameObject.SetActive(true);
		}

		replayAppear = true;
	}

	public void infoClickPause()
	{
		tracker.Stop();

		if (subvideo.isplaying())
			subvideo.pausevideo();

		restart = false;
		infoClick = true;
	}

	public void _restart()
	{
		restart = true;
	}

}
