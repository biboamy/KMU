using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using RenderHeads.Media.AVProVideo;

public class textGuide : MonoBehaviour
{

	public static MediaPlayer audioSource;
	public Text []text;
	public string[] fileName;

	private List<string> index = new List<string>();
	private List<int> timer = new List<int>();
	private List<string> words = new List<string>();

	private List<List<string>> my2d = new List<List<string>>();
	private List<List<int>> my2dTime = new List<List<int>>();
	private List<List<string>> my2dIndex = new List<List<string>>();


	public static bool startTextGuide = false;
	private int audioIndex = 0;
	bool testTXT = true;
	private int subindex = 0;

	public bool testPauseRewind = false;

	public int setsub
	{
		set
		{
			subindex = value;
		}
	}
	// Use this for initialization
	void Start()
	{
		parseText();
	}

	// Update is called once per frame
	void Update()
	{
		if (startTextGuide && my2dIndex[subindex].Count > audioIndex)
		{
		float current = audioSource.Control.GetCurrentTimeMs();

			//Debug.Log(subindex.ToString() + "/" + audioIndex.ToString());
			if (my2dTime[subindex][audioIndex] > current)
			{
				if (audioSource.Control.IsPaused())
				{
					for (int i = 0; i < text.Length; i++)
						text[i].text = "";

					testPauseRewind = true;
				}
				else
				{
					if (testPauseRewind)
					{
						testPauseRewind = false;
						testTXT = true;
					}
				}
				if (testTXT)
				{
					for (int i = 0; i < text.Length; i++)
						text[i].text = my2d[subindex][audioIndex];
					
					//Debug.Log(my2d[subindex][audioIndex]);
					testTXT = false;
				}

			}
			else 
			{
				audioIndex++;
				testTXT = true;
			}
		}
		else
		{
			startTextGuide = false;
			testTXT = true;
			for (int i = 0; i < text.Length; i++)
				text[i].text = "";
			audioIndex = 0;
		}

		if (startTextGuide && audioSource.Control.IsFinished())
		{
			setFinish();
		}
	}

	public void setFinish()
	{
		startTextGuide = false;
		for (int i = 0; i < text.Length; i++)
			text[i].text = "";
		Debug.Log("setfinish");
		audioIndex = 0;
	}

	private void parseText()
	{
		foreach (var trigger in fileName)
		{
			TextAsset asset = (TextAsset)Resources.Load(trigger, typeof(TextAsset));
			string[] splitFile = new string[] { "\r\n", "\r", "\n" };
			string[] fLines = asset.text.Split(splitFile, StringSplitOptions.None);

			for (int i = 0; i < fLines.Length; i++)
			{
				//get index
				index.Add(fLines[i]);
				Debug.Log(fLines[i]);

				//get end value
				i++;
				string[] endTime;
				endTime = fLines[i].Split('>');
				string[] splitTime;
				splitTime = endTime[1].Split(':');
				int getMin; //get min
				int.TryParse(splitTime[1], out getMin);
				string[] secondStr;
				secondStr = splitTime[2].Split(',');
				int getSecond; //get second
				int.TryParse(secondStr[0], out getSecond);
				int getMilliSec; //get milliSecond
				int.TryParse(secondStr[1], out getMilliSec);
				int totalTime = getMin * 60 * 1000 + getSecond * 1000 + getMilliSec; //get time in milliSecond
				timer.Add(totalTime);
				Debug.Log(totalTime.ToString());

				//get text
				i++;
				words.Add(fLines[i]);
				Debug.Log(fLines[i]);

				i++;
			}
			my2d.Add(words);
			my2dTime.Add(timer);
			my2dIndex.Add(index);

			words = new List<string>();
			timer = new List<int>();
			index = new List<string>();
		}
	}


	public void m_setsub(int m)
	{
		subindex = m;

	}
}
