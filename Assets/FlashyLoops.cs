using System;
using System.Linq;
using UnityEngine;

public class FlashyLoops : Area
{
    public string audio_loop_on;
    public string audio_loop_off;
    public string audio_click;

    public float speed = 1;
    AllContent dataActive;
    public AllContent[] data;

    [Serializable]
    public class AllContent
    {
        public GameObject all;
        public GameObject[] content;
        public int contentID;
    }
    int id;
    public override void Show()
    {
        base.Show();
        SetOn();
        
        Loop();
    }
    void SetOn()
    {
        dataActive = data[id];
        for (int i = 0; i < data.Length; i++)
        {
            data[i].all.SetActive(i == id);
        }
        for (int i = 0; i < dataActive.content.Length; i++)
            dataActive.content[i].SetActive(false);
        CancelInvoke();
        plagingLoop = true;
        SetLoop();
        AudioManager.Instance.PlaySound(audio_click, "ui", false);
    }
    GameObject lastLoopActive;
    void Loop()
    {
        if(lastLoopActive != null)
            lastLoopActive.SetActive(false);
        lastLoopActive = dataActive.content[UnityEngine.Random.Range(0, dataActive.content.Length)];
        lastLoopActive.SetActive(true);
        Invoke("Loop", speed/10);
    }
    public override void Next()
    {
        id = (id + 1) % data.Length; // Avanza al siguiente índice, vuelve al inicio si es el último
        SetOn();
    }
    public override void Prev()
    {
        id = (id - 1 + data.Length) % data.Length; // Retrocede al índice anterior, vuelve al final si es el primero
        SetOn();
    }
    bool plagingLoop;
    public override void Action()
    {
        plagingLoop = !plagingLoop;
        SetLoop();
        //dataActive.contentID = (dataActive.contentID + 1) % dataActive.content.Length; // Avanza al siguiente índice, vuelve al inicio si es el último
        // SetOnB();
    }
    void SetLoop()
    {
        CancelInvoke();
        if (plagingLoop)
        {
            AudioManager.Instance.PlaySound(audio_loop_on, "music", true);
            Loop();
        } else
            AudioManager.Instance.PlaySound(audio_loop_off, "music", true);
    }
    public override void Action2()
    {
        //dataActive.contentID = (dataActive.contentID - 1 + dataActive.content.Length) % dataActive.content.Length; // Retrocede al índice anterior, vuelve al final si es el primero
        //SetOnB();
    }
}
