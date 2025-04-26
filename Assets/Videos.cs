using System;
using UnityEngine;
using UnityEngine.Video;

public class Videos : Area
{
    VideoPlayer videoPlayer;
    [SerializeField] VideoClip[] all;
    int id;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
    }
    public override void Show()
    {
        base.Show();
        PlayVideo();
    }
    void PlayVideo()
    {
        videoPlayer.clip = all[id];
        videoPlayer.Play();
    }
    public override void Next()
    {
        if (all.Length == 0) return;

        id = (id + 1) % all.Length; // Avanza al siguiente índice, vuelve al inicio si es el último
        PlayVideo();
    }

    public override void Prev()
    {
        if (all.Length == 0) return;

        id = (id - 1 + all.Length) % all.Length; // Retrocede al índice anterior, vuelve al final si es el primero
        PlayVideo();
    }
}
