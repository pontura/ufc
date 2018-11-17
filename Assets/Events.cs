using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action BackClicked = delegate { };
	public static System.Action SetNextScreen = delegate { };
	public static System.Action SetPrevScreen = delegate { };
	public static System.Action<bool> OnUserStatus = delegate { };
	public static System.Action TakeSnapshot = delegate { };
	public static System.Action Flashit = delegate { };
	public static System.Action<string> SaveImage = delegate { };
	public static System.Action<Texture2D> SetTexture = delegate { };
	public static System.Action<int> OnChangeEnemy = delegate { };
	public static System.Action<string> OnKeyboardDone = delegate { };

}

