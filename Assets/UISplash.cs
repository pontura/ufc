using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISplash : UIScreen {

	public void OnStart()
	{
		Events.SetNextScreen ();
	}
}
