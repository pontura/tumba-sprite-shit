using System;
using UnityEngine;

public class InfoData : MonoBehaviour
{
    [SerializeField] string title = "TUMBA GAMES";
    [SerializeField] string text = "GAMES TO FUCK THE SYSTEM";  

    private void OnEnable()
    {
        if (InfoSignal.Instance == null) return;
        InfoSignal.Instance.ChangeData(title, text);
    }
}
