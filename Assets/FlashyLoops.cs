using System;
using UnityEngine;

public class FlashyLoops : Area
{
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
    }
    void SetOn()
    {
        dataActive = data[id];
        for (int i = 0; i < data.Length; i++)
        {
            data[i].all.SetActive(i == id);
        }
    }
    void SetOnB()
    {
        for (int i = 0; i < dataActive.content.Length; i++)
        {
            dataActive.content[i].SetActive(i == dataActive.contentID);
        }
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
    public override void Action()
    {
        dataActive.contentID = (dataActive.contentID + 1) % dataActive.content.Length; // Avanza al siguiente índice, vuelve al inicio si es el último
        SetOnB();
    }
    public override void Action2()
    {
        dataActive.contentID = (dataActive.contentID - 1 + dataActive.content.Length) % dataActive.content.Length; // Retrocede al índice anterior, vuelve al final si es el primero
        SetOnB();
    }
}
