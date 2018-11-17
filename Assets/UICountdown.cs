using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountdown : UIScreen {

	public Text field;
	int num;

	void OnUserStatus(bool isInZone)
	{
		if (!isInZone) {
			//Events.SetPrevScreen ();
		}
	}
	public override void Init(){
		Events.OnUserStatus += OnUserStatus;
		num = 3;
		Loop ();
	}
	public override void SetOff(){
		Events.OnUserStatus -= OnUserStatus;
		CancelInvoke ();
	}
	void Loop()
	{
		if (num == 0) {
			Events.TakeSnapshot ();
			StartCoroutine (TakePhoto ());
			return;
		}
		field.text = num.ToString ();
		num--;
		Invoke ("Loop", 1);
	}
	IEnumerator TakePhoto()
	{		
		Events.TakeSnapshot ();
		yield return new WaitForSeconds(0.1f);
		Events.Flashit ();	
		Events.SetNextScreen ();
	}
}
