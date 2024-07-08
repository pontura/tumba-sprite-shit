using UnityEngine;

public class MusicBackground : MonoBehaviour
{
    public string bgMusicName;
    public bool musicLoop;

    void OnEnable()
    {
        if (bgMusicName != "")
        {
            string a = "background music/" + bgMusicName;
            AudioManager.Instance.PlaySound(a, "music", musicLoop);
        }
    }
    private void OnDisable()
    {
        AudioManager.Instance.StopSound("music");
    }
}
