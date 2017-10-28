using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsController : MonoBehaviour {
	public GameObject RightPortal;
	public GameObject LeftPortal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenLeft()
	{
		Debug.Log ("OpenLeft");
		LeftPortal.GetComponent<Animator> ().SetTrigger ("Open");
		RightPortal.SetActive (false);
	}

	public void OpenRight()
	{
		Debug.Log ("OpenRight");

		RightPortal.GetComponent<Animator> ().SetTrigger ("Open");
		LeftPortal.SetActive (false);
	}
}
