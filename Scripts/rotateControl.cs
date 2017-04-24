using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateControl : MonoBehaviour
{

	public GameObject rotateOj;
	public bool rotateTrack;

	bool testClick = false;
	int testButton;

	// Use this for initialization
	void Start()
	{

	}

	void Update()
	{
		if (testClick)
		{
			if (testButton == 1)
			{
				Transform myOj = rotateOj.GetComponent<Transform>();
				foreach (Transform rotate in myOj)
				{
					if (rotate.name != "Directional light" && rotate.name != "Directional light (1)")
					{
						if (rotateTrack)
							rotate.Rotate(new Vector3(0, 50, 0) * -Time.deltaTime);
						else
							rotate.Rotate(new Vector3(0, 50, 0) * -Time.deltaTime);
					}
				}
				 
			}
			else if (testButton == 2)
			{
				Transform myOj = rotateOj.GetComponent<Transform>();
				foreach (Transform rotate in myOj)
				{
					if (rotate.name != "Directional light" && rotate.name != "Directional light (1)")
					{
						if (rotateTrack)
							rotate.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
						else
							rotate.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
					}
				}
			}
		}
	}

	//1 for left 2 for right
	public void down(int i)
	{
		testButton = i;
		testClick = true;
	}

	public void up()
	{
		testClick = false;
	}
}
