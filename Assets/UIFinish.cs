using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFinish : UIScreen {

	public override void Init(){
		Invoke ("Done", 3);
	}
	public override void SetOff(){

	}
	void Done()
	{
		Events.SetNextScreen ();
	}
}
