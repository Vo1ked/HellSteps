using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinController : MonoBehaviour {
	private int _tapsCount = 0;

	public GameObject PumpkinPortal;


	public void OnMouseDown()
	{
		_tapsCount++;
		Debug.Log (_tapsCount);
		if(_tapsCount>=3)
		{
		Debug.Log ("ChoosePumpkin");
			StopCoroutine (CountingTime());
			PumpkinPortal.SetActive (false);
			_tapsCount = 0;
		//Add points
		}
	}

	public void StartCounting()
	{
		StartCoroutine (CountingTime());
	}

	private IEnumerator CountingTime()
	{
		Debug.Log ("Start timer");
		yield return new WaitForSeconds (2f);
		YouLoose ();
	}

	public void YouLoose()
	{
		PumpkinPortal.SetActive (false);
	}
}
