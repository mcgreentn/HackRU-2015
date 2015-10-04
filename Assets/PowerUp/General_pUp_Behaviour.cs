using UnityEngine;
using System.Collections;

public class General_pUp_Behaviour : MonoBehaviour {

	private float speed = 100f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
	}
}
