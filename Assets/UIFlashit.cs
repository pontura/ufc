using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFlashit : MonoBehaviour {

	public GameObject panel;

	void Start () {
		panel.SetActive (false);
		Events.Flashit += Flashit;
	}

	void Flashit () {
		panel.SetActive (true);
		Invoke ("Reset", 1.5f);
	}
	void Reset()
	{
		panel.SetActive (false);
	}
}
