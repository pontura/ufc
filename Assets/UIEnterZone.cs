using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnterZone : UIScreen {

	void OnUserStatus(bool isInZone)
	{
		if (isInZone) {
			Events.SetNextScreen ();
		} else {
			Events.SetPrevScreen ();
		}
	}
	public override void Init(){
		print ("______init UIEnterZone" );
		Events.OnUserStatus += OnUserStatus;
	}
	public override void SetOff(){
		print ("________SetOff UIEnterZone" );
		Events.OnUserStatus -= OnUserStatus;
	}
}
