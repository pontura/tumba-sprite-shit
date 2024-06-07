using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipPlayer : MonoBehaviour
{
    public void PlaySound(string s)
    {
        AudioManager.Instance.PlaySoundOneShot("ui", s);
    }
}
