using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantController : MonoBehaviour {
	private int _tapsCount = 0;
	public GameObject LooserScreen;
	public GameObject MutantPortal;


	public void OnMouseDown()
	{
		_tapsCount++;
		Debug.Log (_tapsCount);
		if(_tapsCount>=5)
		{
			StopCoroutine (CountingTime());
			MutantPortal.SetActive (false);
			_tapsCount = 0;
		}
	}

	public void StartCounting()
	{
		StartCoroutine (CountingTime());
	}

	private IEnumerator CountingTime()
	{
		Debug.Log ("Start timer");
		yield return new WaitForSeconds (4f);
		GameOver ();
	}

	public void GameOver()
	{
		LooserScreen.SetActive (true);
		MutantPortal.SetActive (false);
	}
}
