using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {

	public GameObject myUIImage;
	static Image myImage;

	// Use this for initialization
	void Start () {
		myImage = myUIImage.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void changeSourceImage(bool isPlaying)
	{
		if (!isPlaying)
		{
			//Debug.Log("no");
			myImage.enabled = false;
		}
		else
		{
			//Debug.Log("yes");
			myImage.enabled = true;
		}

	}
}
