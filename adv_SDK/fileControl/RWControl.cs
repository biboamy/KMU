using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cqplayart.amy.RWControl;

public class RWControl : MonoBehaviour {

	static myRWControl myControl;
	public string filename;
	public string fileMessage;

	Text message;

	// Use this for initialization
	void Start () {

		message = GameObject.Find("message").GetComponent<Text>();
		myControl = new RWInterfaceBehavior();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void write()
	{
		myControl.writefile(filename, fileMessage);
	}

	public void read()
	{
		if (myControl.readfile(filename) == null)
			message.text = "please write the file first";
		else
			message.text = myControl.readfile(filename);
	}

	public void delete()
	{
		myControl.deleteFile(filename);
	}
}
