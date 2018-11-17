using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class UIEmail : UIScreen {

	public Text debbugText;
	public KeyboardPanel keyBoardPanel;

	public override void Init(){
		keyBoardPanel.Init (true);
	}
	public override void SetOff(){

	}
	public void SendEmail(string content)
	{	
		Events.SaveImage (content);
		debbugText.text = "Enviando...";
		Invoke ("Sended", 2);

	}
	void ResetLog()
	{		
		debbugText.text = "";
	}
	public void CancelClicked()
	{
		Events.SetNextScreen ();
	}
	void Sended()
	{
		Events.SetNextScreen ();
	}
}
