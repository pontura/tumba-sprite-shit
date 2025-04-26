using Unity.VisualScripting;
using UnityEngine;

public class Area : MonoBehaviour
{
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    public virtual void Next()
    {
    }
    public virtual void Prev()
    {
    }
    public virtual void Action()
    {
    }
    public virtual void Action2()
    {
    }
}
