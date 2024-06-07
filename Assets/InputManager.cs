using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public types type;
    public enum types
    {
        random,
        action,
        loop,
        evolutive
    }
    enum state
    {
        sprites
    }
    [SerializeField] GameObject[] sprites;
    int num = 0;
    Animator anim;
    AnimationClip[] anims;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Next();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            Prev();
        else if (Input.GetKeyDown(KeyCode.Space))
            Action();
        else if (Input.GetKeyDown(KeyCode.LeftControl))
            Action2();
    }
    void Next()
    {
        num++;
        if (num > sprites.Length - 1) num = 0;
        SetActive();
    }
    void Prev()
    {
        num--;
        if (num < 0) num = sprites.Length - 1;
        SetActive();
    }
    void SetActive()
    {
        foreach (GameObject go in sprites)
            go.SetActive(false);

        GameObject active = sprites[num];
        string n = active.name;

        string[] arr = n.Split(":"[0]);
        if (arr.Length > 1)
        {
            switch (arr[1])
            {
                case "random" : type = types.random; break;
                case "action": type = types.action;  break;
                case "loop": type = types.loop; break;
                case "evolutive": type = types.evolutive; break;
            }
        }
        animID = 0;
        active.SetActive(true);
        anims = null;
        anim = active.GetComponentInChildren<Animator>();
        if(anim != null)
            anims = anim.runtimeAnimatorController.animationClips;
        StartAction();
    }
    void Action()
    {
        StartAction();
    }
    void Action2()
    {
        StartAction();
    }
    int animID = -1;
    void StartAction()
    {
        if (anims == null) return;
        if (anims.Length < 2) return;
        switch(type)
        {
            case types.random:
                int rand = Random.Range(0, anims.Length);
                if (animID == rand)
                    StartAction();
                else
                    animID = rand;
                break;
            case types.loop:
                animID++;
                if (animID > anims.Length-1)
                    animID = 0;
                break;
            case types.evolutive:
                animID++;
                if (animID > anims.Length-1)
                    animID = anims.Length - 1;
                break;
            case types.action:
                animID = 1;
                break;
        }
        string animName = anims[animID].name;
        anim.Play(animName, -1, 0f);
        //foreach (AnimationClip ac in anim.runtimeAnimatorController.animationClips)
        //{
        //    // look at all the animation clips here!
        //}
    }
}
