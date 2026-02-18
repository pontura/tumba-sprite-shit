using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] AreasManager areasManager;
    [SerializeField] Image callToActionImage;

    int secsToCallToAction = 20;

    float timer;
    [SerializeField] bool callToAction;

    void Start()
    {
        Invoke("CallToAction", 0.1f);
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            timer = 0;
            callToAction = false;
        }
        if (!callToAction)
        {          
            timer += Time.deltaTime;
            if (timer > secsToCallToAction)
            {
                CallToAction();
            }
            if (Input.GetKey(KeyCode.Alpha2))
                FadeCallToAction();
            if (Input.GetKeyUp(KeyCode.Alpha2))
                ResetCallToAction();
        }
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
        else if (Input.GetKeyDown(KeyCode.Return))
            areasManager.Action2();
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            areasManager.Info(true);
        else if (Input.GetKeyUp(KeyCode.Alpha1))
            areasManager.Info(false);
       
    }
    void CallToAction()
    {
        alpha = 0;
        callToActionImage.color = new Color(0,0,0, alpha);
        timer = 0;
        callToAction = true;
        areasManager.CallToAction();
    }

    float callToActionSpeed = 0.5f;
    float alpha = 0;

    void FadeCallToAction()
    {
        alpha += Time.deltaTime * callToActionSpeed;
        if (alpha >= 1)
            CallToAction();
        else
            callToActionImage.color = new Color(0, 0, 0, alpha);
    }
    void ResetCallToAction()
    {
        alpha = 0;
        callToActionImage.color = new Color(0, 0, 0, alpha);
    }
}
