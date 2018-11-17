using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoster : MonoBehaviour {

	public GameObject panel;
	public Text field;
	public Image image;

	public GameObject[] enemies;
	public GameObject[] enemiesFields;

	void Start () {
		Events.SetTexture += SetTexture;
		Events.OnChangeEnemy += OnChangeEnemy;
		panel.SetActive (false);
		Reset ();
		OnChangeEnemy (0);
	}
	public void SetOn()
	{
		panel.SetActive (true);
		image.enabled = false;
	}
	void OnDestroy () {
		Events.SetTexture -= SetTexture;
		Events.OnChangeEnemy -= OnChangeEnemy;
	}
	void OnChangeEnemy(int id)
	{
		foreach (GameObject go in enemies)
			go.SetActive (false);

		foreach (GameObject go in enemiesFields)
			go.SetActive (false);

		enemies [id].SetActive (true);
		enemiesFields [id].SetActive (true);
	}
	void SetTexture(Texture2D texture)
	{
		image.enabled = true;
		panel.SetActive (true);
		image.material.mainTexture = texture;
	}
	public void Reset()
	{
		panel.SetActive (false);
	}
	public void SetName(string username)
	{
		field.text = username;
	}
}
