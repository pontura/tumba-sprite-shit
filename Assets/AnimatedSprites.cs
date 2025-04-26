using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprites : Area
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
    public override void Show()
    {
        base.Show();
        SetActive();
    }
    public override void Next()
    {
        animID = 0;
        num++;
        if (num > sprites.Length - 1) num = 0;
        SetActive();
    }
    public override void Prev()
    {
        animID = 0;
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
                case "random": type = types.random; break;
                case "action": type = types.action; break;
                case "loop": type = types.loop; break;
                case "evolutive": type = types.evolutive; break;
            }
        }
        animID = 0;
        active.SetActive(true);
        anims = null;
        anim = active.GetComponentInChildren<Animator>();
        if (anim != null)
            anims = anim.runtimeAnimatorController.animationClips;
        StartAction();
    }
    public override void Action()
    {
        StartAction();
    }
    public override void Action2()
    {
        StartAction();
    }
    int animID = -1;
    void StartAction()
    {
        if (anims == null) return;
        if (anims.Length < 2) return;
        switch (type)
        {
            case types.random:
                int rand = Random.Range(0, anims.Length);
                if (animID == rand)
                    StartAction();
                else
                    animID = rand;
                break;
            case types.loop:
                anim.Play(anims[animID].name, -1, 0f);
                animID++;
                if (animID > anims.Length - 1)
                    animID = 0;
                return;
            case types.evolutive:
                anim.Play(anims[animID].name, -1, 0f);
                animID++;
                if (animID > anims.Length - 1)
                    animID = anims.Length - 1;
                return;
            case types.action:
                animID = 1;
                break;
        }
        string animName = anims[animID].name;
        anim.Play(animName, -1, 0f);
    }
}
