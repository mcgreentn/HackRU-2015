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

    public void stage3Pressed()
    {
        Application.LoadLevel("stage3");
    }
    public void stage4Pressed()
    {
        Application.LoadLevel("stage4");
    }

    public void stage5Pressed()
    {
        Application.LoadLevel("stage5");
    }
}
