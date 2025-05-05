using System;
using System.Linq;
using UnityEngine;

public class FlashyLoops : Area
{
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
        id = (id + 1) % data.Length; // Avanza al siguiente �ndice, vuelve al inicio si es el �ltimo
        SetOn();
    }
    public override void Prev()
    {
        id = (id - 1 + data.Length) % data.Length; // Retrocede al �ndice anterior, vuelve al final si es el primero
        SetOn();
    }
    bool plagingLoop;
    public override void Action()
    {
        plagingLoop = !plagingLoop;
        SetLoop();
        //dataActive.contentID = (dataActive.contentID + 1) % dataActive.content.Length; // Avanza al siguiente �ndice, vuelve al inicio si es el �ltimo
        // SetOnB();
    }
    void SetLoop()
    {
        CancelInvoke();
        if (plagingLoop)
            Loop();
    }
    public override void Action2()
    {
        //dataActive.contentID = (dataActive.contentID - 1 + dataActive.content.Length) % dataActive.content.Length; // Retrocede al �ndice anterior, vuelve al final si es el primero
        //SetOnB();
    }
}
