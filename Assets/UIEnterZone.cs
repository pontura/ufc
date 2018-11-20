using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnterZone : UIScreen {

	bool started;
	void OnUserStatus(bool isInZone)
	{
		if (isInZone) {
			Events.SetNextScreen ();
		} else {
			Events.SetPrevScreen ();
		}
	}
	public override void Init(){
		if (started)
			return;
		started = true;
		Events.OnUserStatus += OnUserStatus;
	}
	public override void SetOff(){
		started = false;
		Events.OnUserStatus -= OnUserStatus;
	}
}
