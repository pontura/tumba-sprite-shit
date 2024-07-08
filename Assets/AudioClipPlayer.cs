using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipPlayer : MonoBehaviour
{
    public string[] clips;


    public void PlaySound(string s)
    {
        AudioManager.Instance.PlaySoundOneShot("ui", s);
    }
    public void PlayRandomClipFromList()
    {
        if (clips.Length == 0) return;
        string _s = clips[Random.Range(0, clips.Length-1)];
        AudioManager.Instance.PlaySoundOneShot("ui", _s);
    }
  
}
