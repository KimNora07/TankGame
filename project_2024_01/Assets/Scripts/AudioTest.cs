using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public void PlayBGM(string name){
        AudioManager.Instance.PlayMusic(name);
    }

    public void PlaySFX(string name){
        AudioManager.Instance.PlaySFX(name);
    }
}
