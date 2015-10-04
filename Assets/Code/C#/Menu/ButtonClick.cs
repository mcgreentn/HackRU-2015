using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour
{
    

    public void playPressed()
    {
        Application.LoadLevel("stages");
    }

    public void stage1Pressed()
    {
        Application.LoadLevel("stage1");
    }

    public void stage2Pressed()
    {
        Application.LoadLevel("stage2");
    }
}
