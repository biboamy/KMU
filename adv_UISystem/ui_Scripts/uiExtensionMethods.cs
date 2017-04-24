using UnityEngine;
using System.Collections;
using AdvUIM;


//It is common to create a class to contain all of your
//extension methods. This class must be static.
public static class uiExtensionMethods {


		//Even though they are used like normal methods, extension
		//methods must be declared static. Notice that the first
		//parameter has the 'this' keyword followed by a Transform
		//variable. This variable denotes which class the extension
		//method becomes a part of.


	/*
	public static void show(this uimNaviBar mNaviBar)
	{
		AdvUIM.uimNaviBar.InstanceManager.SetStatus(AdvUIM.uimNaviBar.Status.show);
		//AdvUIM.uimStarMenu.InstanceManager.currentStatus = AdvUIM.uimStarMenu.Status.show;
		//AdvUIM.uimStarMenu.InstanceManager.SetStatus ();
	}

	public static void hide(this uimNaviBar mNaviBar)
	{
		AdvUIM.uimNaviBar.InstanceManager.SetStatus(AdvUIM.uimNaviBar.Status.hide);
		//AdvUIM.uimStarMenu.InstanceManager.currentStatus = AdvUIM.uimStarMenu.Status.show;
		//AdvUIM.uimStarMenu.InstanceManager.SetStatus ();
	}

	public static void show(this uimTrackImageList mTrackImageList)
	{
		AdvUIM.uimTrackImageList.InstanceManager.SetStatus(AdvUIM.uimTrackImageList.Status.show);
	}

	public static void hide(this uimTrackImageList mTrackImageList)
	{
		AdvUIM.uimTrackImageList.InstanceManager.SetStatus(AdvUIM.uimTrackImageList.Status.hide);
	}

	public static void show(this uimFinder mFinder)
	{
		AdvUIM.uimFinder.InstanceManager.SetStatus(AdvUIM.uimFinder.Status.show);
	}

	public static void hide(this uimFinder mFinder)
	{
		AdvUIM.uimFinder.InstanceManager.SetStatus(AdvUIM.uimFinder.Status.hide);
	}




	public static void show(this uimMenuMap mMenuMap)
	{
		AdvUIM.uimMenuMap.InstanceManager.SetStatus(AdvUIM.uimMenuMap.Status.show);
	}

	public static void hide(this uimMenuMap mMenuMap)
	{
		AdvUIM.uimMenuMap.InstanceManager.SetStatus(AdvUIM.uimMenuMap.Status.hide);
	}



	public static void show(this 	uimMenuNaviBar mMenuNaviBar)
	{
		AdvUIM.uimMenuNaviBar.InstanceManager.SetStatus(AdvUIM.uimMenuNaviBar.Status.show);
	}

	public static void hide(this 	uimMenuNaviBar mMenuNaviBar)
	{
		AdvUIM.uimMenuNaviBar.InstanceManager.SetStatus(AdvUIM.uimMenuNaviBar.Status.hide);
	}


	public static void show(this 	uimMenuList mMenuList)
	{
		AdvUIM.uimMenuList.InstanceManager.SetStatus(AdvUIM.uimMenuList.Status.show);
	}

	public static void hide(this 	uimMenuList mMenuList)
	{
		AdvUIM.uimMenuList.InstanceManager.SetStatus(AdvUIM.uimMenuList.Status.hide);
	}

	public static void progress(this uimMenuList mMenuList, double progressValue)
	{
		AdvUIM.uimMenuList.InstanceManager.UpdateProgress (progressValue);
	}

*/

	//Splash
	public static void show(this uimSplash mSplash)
	{
		AdvUIM.uimSplash.InstanceManager.SetStatus(AdvUIM.uimSplash.Status.show);
	}

	public static void hide(this uimSplash mSplash)
	{
		AdvUIM.uimSplash.InstanceManager.SetStatus(AdvUIM.uimSplash.Status.hide);
	}

	public static void hideInSec(this uimSplash mSplash, float waitSec)
	{
		AdvUIM.uimSplash.InstanceManager.AutoHideSplash (waitSec);
		//AdvUIM.uimSplash.InstanceManager.SetStatus(AdvUIM.uimSplash.Status.hide);
	}


	//Loading
	public static void show(this uimLoadingInScene mLoadingInScene)
	{
		AdvUIM.uimLoadingInScene.InstanceManager.SetStatus(AdvUIM.uimLoadingInScene.Status.show);
	}

	public static void hide(this uimLoadingInScene mLoadingInScene)
	{
		AdvUIM.uimLoadingInScene.InstanceManager.SetStatus(AdvUIM.uimLoadingInScene.Status.hide);
	}


	public static void progress(this uimLoadingInScene mLoadingInScene, double progressValue)
	{
		AdvUIM.uimLoadingInScene.InstanceManager.UpdateProgress (progressValue);
	}

	public static void fakeProgress(this uimLoadingInScene mLoadingInScene, float progressValue)
	{
		AdvUIM.uimLoadingInScene.InstanceManager.FakeUpdateProgress (progressValue);
	}


	//Poweredby
	public static void show(this uimPoweredBy mPoweredBy)
	{
		AdvUIM.uimPoweredBy.InstanceManager.SetStatus(AdvUIM.uimPoweredBy.Status.show);
	}

	public static void hide(this uimPoweredBy mPoweredBy)
	{
		AdvUIM.uimPoweredBy.InstanceManager.SetStatus(AdvUIM.uimPoweredBy.Status.hide);
	}

	//Menu
	public static void show(this uimMenu mMenu)
	{
		AdvUIM.uimMenu.InstanceManager.SetStatus(AdvUIM.uimMenu.Status.show);
	}

	public static void hide(this uimMenu mMenu)
	{
		AdvUIM.uimMenu.InstanceManager.SetStatus(AdvUIM.uimMenu.Status.hide);
	}

	//uimInstruction1
	public static void show(this uimInstruction1 mInstruction1)
	{
		AdvUIM.uimInstruction1.InstanceManager.SetStatus(AdvUIM.uimInstruction1.Status.show);
	}

	public static void hide(this uimInstruction1 mInstruction1)
	{
		AdvUIM.uimInstruction1.InstanceManager.SetStatus(AdvUIM.uimInstruction1.Status.hide);
	}


	//uimInstruction2
	public static void show(this uimInstruction2 mInstruction2)
	{
		AdvUIM.uimInstruction2.InstanceManager.SetStatus(AdvUIM.uimInstruction2.Status.show);
	}

	public static void hide(this uimInstruction2 mInstruction2)
	{
		AdvUIM.uimInstruction2.InstanceManager.SetStatus(AdvUIM.uimInstruction2.Status.hide);
	}


	//uimNaviBar
	public static void show(this uimNaviBar mNaviBar)
	{
		AdvUIM.uimNaviBar.InstanceManager.SetStatus(AdvUIM.uimNaviBar.Status.show);
	}

	public static void hide(this uimNaviBar mNaviBar)
	{
		AdvUIM.uimNaviBar.InstanceManager.SetStatus(AdvUIM.uimNaviBar.Status.hide);
	}

	public static void changeTitle(this uimNaviBar mNaviBar,int setNo)
	{
		AdvUIM.uimNaviBar.InstanceManager.ChangeNaviBarTitle (setNo);
	}

	//AR Control
	public static void show(this uimARControl mARControl)
	{
		AdvUIM.uimARControl.InstanceManager.SetStatus(AdvUIM.uimARControl.Status.show);
	}

	public static void hide(this uimARControl mARControl)
	{
		AdvUIM.uimARControl.InstanceManager.SetStatus(AdvUIM.uimARControl.Status.hide);
	}

	//Finder (Track)
	public static void show(this uimFinder mFinder)
	{
		AdvUIM.uimFinder.InstanceManager.SetStatus(AdvUIM.uimFinder.Status.show);
	}

	public static void hide(this uimFinder mFinder)
	{
		AdvUIM.uimFinder.InstanceManager.SetStatus(AdvUIM.uimFinder.Status.hide);
	}
}
