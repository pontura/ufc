using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScale : MonoBehaviour {

	public Vector3 scale;

	void Update () {
		transform.localScale = scale;
	}
}
