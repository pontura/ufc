using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIntro : UIScreen {

	public Dropdown dropDown;
	public int enemyID;
	public KeyboardPanel keyBoardPanel;

	public override void Init(){
		keyBoardPanel.Init (false);
		dropDown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(dropDown);
		});
	}
	public override void SetOff(){
		
	}
	void DropdownValueChanged(Dropdown d)
	{
		print (d.value);
		Events.OnChangeEnemy (d.value);
	}
	public void OnUsername(string username)
	{
		Events.OnChangeEnemy (dropDown.value);
		GetComponent<UIPoster> ().SetName (username.ToUpper());
		Events.SetNextScreen ();
	}
}
