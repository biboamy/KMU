using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HedgehogTeam.EasyTouch;
using UnityEngine.UI;

public class myFirstTouch : MonoBehaviour {

	public GameObject thisOj;

	void Start()
	{

		//EasyTouch.On_TouchStart += MyTouchStart;
		//EasyTouch.On_TouchDown += MyTouchDown;


	}

	void OnDisable()
	{
		
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit rayHit;
			Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(myRay, out rayHit))
			{
				Debug.Log(rayHit.transform.name);
				if (rayHit.transform.name == "floor_circle")
				{
					Material render = rayHit.transform.gameObject.GetComponent<MeshRenderer>().material;
					if (render.name.Contains("wood_001_01"))
					{
						render = Resources.Load("yogamat_002", typeof(Material)) as Material; 
					}
					else if (render.name.Contains("yogamat_002"))
					{
						render = Resources.Load("carpets_001", typeof(Material)) as Material; 
					}
					else {
						render = Resources.Load("wood_001_01", typeof(Material)) as Material; 
					}
					rayHit.transform.gameObject.GetComponent<MeshRenderer>().material = render;
				}
			}
		}
	}

/*
	void MyTouchStart(Gesture gesture)
	{
		if (gesture.pickedObject != null && gesture.pickedObject.name.Contains("3D_models") && gesture.pickedObject == thisOj)
		{
			foreach (Transform child in gesture.pickedObject.GetComponentsInChildren<Transform>())
			{
				
			}
		}

	}

	void MyTouchDown(Gesture gesture)
	{
			
	}
// ******touch*******/
}
