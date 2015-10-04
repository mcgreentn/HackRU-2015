using UnityEngine;
using System.Collections;

public class Music_Background : MonoBehaviour {


	public AudioClip[] audioClip;
	// Use this for initialization
	void Start () {
		PlaySound (0);
	}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play();
	}
	

}
