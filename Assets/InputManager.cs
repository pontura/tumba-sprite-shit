using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] AreasManager areasManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            areasManager.NextArea();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            areasManager.PrevArea();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            areasManager.Next();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            areasManager.Prev();
        else if (Input.GetKeyDown(KeyCode.Space))
            areasManager.Action();
        else if (Input.GetKeyDown(KeyCode.LeftControl))
            areasManager.Action2();
        else if (Input.GetKeyDown(KeyCode.Z))
            areasManager.Info(true);
        else if (Input.GetKeyUp(KeyCode.Z))
            areasManager.Info(false);
    }
}
