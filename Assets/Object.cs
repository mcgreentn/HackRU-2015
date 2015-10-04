using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Action_LevelSelection()
    {
        Application.LoadLevel("stages");
    }

    public void Action_QuitGame()
    {
        Application.Quit();
    }
}
