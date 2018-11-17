using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour {

	public GameObject panel;
	public void SetState(bool isOn)
	{
		panel.SetActive (isOn);
		if (isOn)
			Init ();
		else
			SetOff ();
	}
	public virtual void Init(){
	}
	public virtual void SetOff(){
	}
}
