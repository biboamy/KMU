using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;
using cqplayart.amy.RWControl;
using System;
using Vuforia;
using System.Collections;
using RenderHeads.Media.AVProVideo;

public class QRcodeTrigger : MonoBehaviour,ITrackableEventHandler
{
    public GameObject ScreenModel;
    public GameObject holder;
    public GameObject trackParameters;
    public GameObject screenParameters;

    private TrackableBehaviour mTrackableBehaviour;
    private bool isTracked = false;

	//for read file
	static myRWControl myControl;
	static private string filename = "testSecond";

	private bool testFirstEnter = true;


    // Use this for initialization
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

		myControl = new RWInterfaceBehavior();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if(this.gameObject.activeSelf)
                onTracking();
        }
        else
        {
            if (this.gameObject.activeSelf)
                onTrackingLost();
        }
    }

    private void onTracking()
    {
		QualitySettings.shadowDistance = 5000F;

		GameObject.Find("rotataion_control").GetComponent<rotateControl>().rotateTrack = true;

		//set title
		string[] Oj = mTrackableBehaviour.TrackableName.Split('k');
		AdvUIM.uimNaviBar.InstanceManager.ChangeNaviBarTitle(int.Parse(Oj[1]));

		//set subtitlee
		GameObject.Find("videoObject").GetComponent<testVideo>().nowPlaying = int.Parse(Oj[1]);

		//test change between each tracking image
		initialText();

		//set all model dissappear
		reset();

		//set model appear
		ScreenModel.SetActive(true);

		//set ar button
		Transform[] trs = GameObject.Find("UIM").GetComponent<Transform>().GetChild(2).gameObject.GetComponentsInChildren<Transform>(true);
		foreach (Transform child in trs)
			child.gameObject.SetActive(true);
		AdvUIM.uimARControl.InstanceManager.IsShown = false;

		//set rotation oj
		setRotateOj(Oj[1]);

        ScreenModel.transform.parent = this.gameObject.transform;
        ScreenModel.transform.localPosition 
            = new Vector3(trackParameters.GetComponent<Transform>().localPosition.x, trackParameters.GetComponent<Transform>().localPosition.y, trackParameters.GetComponent<Transform>().localPosition.z);
        ScreenModel.transform.localEulerAngles 
            = new Vector3(trackParameters.GetComponent<Transform>().localEulerAngles.x, trackParameters.GetComponent<Transform>().localEulerAngles.y, trackParameters.GetComponent<Transform>().localEulerAngles.z);
        ScreenModel.transform.localScale 
            = new Vector3(trackParameters.GetComponent<Transform>().localScale.x, trackParameters.GetComponent<Transform>().localScale.y, trackParameters.GetComponent<Transform>().localScale.z);

        isTracked = true;

		//ui appear
		Debug.Log("open4");
		showUI();
    }

    private void onTrackingLost()
    {
		QualitySettings.shadowDistance = 30F;

		GameObject.Find("rotataion_control").GetComponent<rotateControl>().rotateTrack = false;

        if (isTracked)
        {
            ScreenModel.transform.parent = holder.transform;
            ScreenModel.transform.localPosition 
                = new Vector3(screenParameters.GetComponent<Transform>().localPosition.x, screenParameters.GetComponent<Transform>().localPosition.y, screenParameters.GetComponent<Transform>().localPosition.z);
            ScreenModel.transform.localEulerAngles 
                = new Vector3(screenParameters.GetComponent<Transform>().localEulerAngles.x, screenParameters.GetComponent<Transform>().localEulerAngles.y, screenParameters.GetComponent<Transform>().localEulerAngles.z);
            ScreenModel.transform.localScale 
                = new Vector3(screenParameters.GetComponent<Transform>().localScale.x, screenParameters.GetComponent<Transform>().localScale.y, screenParameters.GetComponent<Transform>().localScale.z);
            ScreenModel.SetActive(true);
        }
    }

	//if tracking image change, then initial subtitle control value
	private void initialText()
	{
		myRWControl control = new RWInterfaceBehavior();
		if (control.readfile("firstTrack") != null)
		{
			subVideo subvideo = GameObject.Find("videoObject").GetComponent<subVideo>();
			subvideo.pausevideo();
			GameObject.Find("textObject").GetComponent<textGuide>().setFinish();
			GameObject.Find("textObject").GetComponent<textGuide>().testPauseRewind = true;
			textGuide.startTextGuide = true;
		}
	}

	//set the rotation control model
	private void setRotateOj(string number)
	{
		rotateControl control = GameObject.Find("rotataion_control").GetComponent<rotateControl>();
		control.rotateOj = GameObject.Find("3D_models" + number);
	}

	//show UI objects
	private void showUI()
	{
		//show finder
		AdvUIM.uimFinder.InstanceManager.IsShown = false;

		if (myControl.readfile(filename) == null)
		{
			AdvUIM.uimInstruction2.InstanceManager.IsShown = true;
			myControl.writefile(filename, "1");

			ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
			tracker.Stop();
		}
		else
		{
			testVideo script = GameObject.Find("videoObject").GetComponent<testVideo>();
			script.videoStart();
		}

		//AdvUIM.uimARControl.InstanceManager.IsShown = true;
		Transform[] trs = GameObject.Find("07navibar").GetComponent<Transform>().GetChild(0).gameObject.GetComponentsInChildren<Transform>(true);
		foreach (Transform t in trs)
		{
			if (t.name == "nav_Q")
			{
				t.gameObject.SetActive(true);
			}
		}
	}

	//reset all objects value first before change to another tracing object
	public void reset()
	{
		for (int i = 0; i < 12; i++)
		{
			foreach (GameObject showOj in GameObject.FindObjectsOfType(typeof(GameObject)))
			{
				if (showOj.name == "3D_models" + (i + 1).ToString())
				{
					showOj.SetActive(false);
				}
			}
		}
	}

}
