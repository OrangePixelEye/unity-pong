using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public void Play()
    {
        GameManager.Instance.ChangeScene(2);
    }

    public void ChangeSound(bool sounds)
    {
        GameManager.Instance.Play_Sounds = sounds;
    }

    public void Exit()
    {
        GameManager.Instance.ExitGame();
    }
}
