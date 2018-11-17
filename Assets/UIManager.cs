using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	UISplash uiSplash;
	UIPoster uiPoster;
	UIIntro intro;
	UIEnterZone enterZone;
	UICountdown countdown;
	UIEmail email;
	UIFinish finish;
	public KinectManager kinectManager_to_instantiate;
	public KinectManager kinectManager;

	int id;
	UIScreen activeUIScreen;

	void Start () {

		uiSplash = GetComponent<UISplash> ();
		intro = GetComponent<UIIntro> ();
		enterZone = GetComponent<UIEnterZone> ();
		countdown = GetComponent<UICountdown> ();
		email = GetComponent<UIEmail> ();
		finish = GetComponent<UIFinish> ();
		uiPoster = GetComponent<UIPoster> ();

		Events.SetNextScreen += SetNextScreen;
		Events.SetPrevScreen += SetPrevScreen;


		Init ();
	}
	void Init()
	{
		id=0;
		SetScreen ();
	}
	void SetNextScreen()
	{
		print ("SetNextScreen " + id);
		if (id >= 5)
			id = 0;
		else
			id++;
		SetScreen ();
	}
	void SetPrevScreen()
	{
		if (id <= 0)
			id = 0;
		else
			id--;
		SetScreen ();
	}
	void SetKinect(bool isOn)
	{
		if (isOn) {
			if (kinectManager == null)
				kinectManager = Instantiate (kinectManager_to_instantiate);
		} else {
			if (kinectManager != null)
				Destroy (kinectManager.gameObject);
		}
	}
	void SetScreen()
	{		
		ResetAll ();
		switch (id) {
		case 0:
			activeUIScreen = uiSplash;
			break;
		case 1:
			uiPoster.Reset ();
			activeUIScreen = intro;
			break;
		case 2:
			uiPoster.SetOn ();
			SetKinect (true);
			activeUIScreen = enterZone;
			break;
		case 3:
			activeUIScreen = countdown;
			break;
		case 4:
			SetKinect (false);
			uiPoster.Reset ();
			activeUIScreen = email;
			break;
		case 5:
			activeUIScreen = finish;
			break;
		}
		activeUIScreen.SetState (true);

	}
	void ResetAll()
	{
		uiSplash.SetState (false);
		intro.SetState (false);
		enterZone.SetState (false);
		countdown.SetState (false);
		email.SetState (false);
		finish.SetState (false);
	}

}
