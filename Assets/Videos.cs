using System;
using UnityEngine;
using UnityEngine.Video;

public class Videos : Area
{
    [Serializable]
    public class VideoInfoData
    {
        public string title = "TUMBA GAMES";
        public string text = "GAMES TO FUCK THE SYSTEM";
    }

    public VideoInfoData[] infoData;
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
        AudioManager.Instance.PlaySound("", "music", true);
    }
    void PlayVideo()
    {
        VideoInfoData v = infoData[id];
        InfoSignal.Instance.ChangeData(v.title, v.text);
        videoPlayer.clip = all[id];
        videoPlayer.Play();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            Back();
        else if (Input.GetKey(KeyCode.RightArrow))
            Fast();
        else
            Idle();
    }
    public void Idle()
    {
        print("Idle");
        videoPlayer.playbackSpeed = 1;
    }
    public void Fast()
    {
        print("Fast");
        videoPlayer.playbackSpeed = 2.5f;
    }
    public void Back()
    {
        print("Back");
        videoPlayer.playbackSpeed = 0.2f;
    }
    public override void Action()
    {
        if (all.Length == 0) return;

        id = (id + 1) % all.Length; // Avanza al siguiente índice, vuelve al inicio si es el último
        PlayVideo();
    }
    public override void Action2()
    {
        if (all.Length == 0) return;

        id = (id - 1 + all.Length) % all.Length; // Retrocede al índice anterior, vuelve al final si es el primero
        PlayVideo();
    }
}
