using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class KeyboardPanel : MonoBehaviour {

	public bool isEmail;
	public string[] fields;
	public Transform container;
	public Text field;
	public Text defaultText;
	public Text errorField;
	public UIEmail uiemail;
	public UIIntro uiIntro;

	public void Init(bool _isEmail)
	{
		field.text = "";
		this.isEmail = _isEmail;
		errorField.text = "";
		defaultText.gameObject.SetActive (true);
		int a = 0;
		foreach (KeyboardButton keyboardButton in container.GetComponentsInChildren<KeyboardButton>()) {
			keyboardButton.Init (this, fields [a]);
			a++;
		}
		defaultText.gameObject.SetActive (true);
	}
	void OnEnable()
	{
		//field.text = "";
		errorField.text = "";
	}
	public void Clicked(string text)
	{
		if (text == "<") {
			if (field.text.Length > 0)
				field.text = field.text.Remove (field.text.Length - 1, 1);
		} else if (text == "OK") {
			if (isEmail) {
				if (validateEmail (field.text))
					uiemail.SendEmail (field.text);
				else
					errorField.text = "Email incorrecto";
			}
			else if (field.text.Length > 1) {
				uiIntro.OnUsername (field.text);
			} 
		}
		else
			field.text += text;

		if(text.Length==0)
			defaultText.gameObject.SetActive (true);
		else
			defaultText.gameObject.SetActive (false);
	}
	bool validateEmail (string email)
	{
		if (email != null)
			return Regex.IsMatch (email, MatchEmailPattern);
		else
			return false;
	}



	string MatchEmailPattern =
	@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
+ @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
+ @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
+ @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

	
}
