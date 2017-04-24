using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	void Awake(){

		//初始化UIM下所有模組 setActive(true) & 回歸中心點
		//Initialise all modules under UIM,  setActive(true) & return to centre of canvas.
		for(int i=0;i<transform.childCount;i++){
			transform.GetChild (i).gameObject.SetActive (true);

			var rectPosition = transform.GetChild (i).GetComponent<RectTransform> ();
			rectPosition.offsetMax = rectPosition.offsetMin = new Vector2 (0, 0);
		}



	}

	// Use this for initialization
	void Start () {
		SetOrientationLandscape ();
		///*
		//AdvUIM.uimLoadingInScene.InstanceManager.show ();
		AdvUIM.uimLoadingInScene.InstanceManager.progress (0);
		AdvUIM.uimLoadingInScene.InstanceManager.show();
		AdvUIM.uimSplash.InstanceManager.show ();
		AdvUIM.uimSplash.InstanceManager.AutoHideSplash (1);
	
		AdvUIM.uimLoadingInScene.InstanceManager.fakeProgress (1);
		AdvUIM.uimMenu.InstanceManager.show ();
		//AdvUIM.uimInstruction1.InstanceManager.show ();
		//AdvUIM.uimInstruction2.InstanceManager.show ();
		AdvUIM.uimARControl.InstanceManager.show ();
		AdvUIM.uimFinder.InstanceManager.show ();
		AdvUIM.uimNaviBar.InstanceManager.show ();
		AdvUIM.uimNaviBar.InstanceManager.changeTitle (0);
		//*/



	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void SetOrientationLandscape(){
		Screen.orientation = ScreenOrientation.Landscape;
	}
	public void SetOrientationPortrait(){
		Screen.orientation = ScreenOrientation.Portrait;

	}
}
