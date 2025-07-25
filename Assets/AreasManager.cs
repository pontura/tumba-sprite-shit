using UnityEditor;
using UnityEngine;

public class AreasManager : MonoBehaviour
{
    [SerializeField] InfoSignal infoSignal;

    public Area[] areas;
    Area area;
    int id;
    private void Start()
    {
        infoSignal.SetOn(false);
        SetArea();
    }
    private void SetArea()
    {
        area = areas[id];

        foreach (Area a in areas)
            a.Hide();

        area.Show();
    }
    public void NextArea()
    {
        id++;
        if (id >= areas.Length)
            id = 0;
        SetArea();
    }
    public void PrevArea()
    {
        id--;
        if (id < 0)
            id = areas.Length-1;
        SetArea();
    }
    public void Next()
    {
        area.Next();
    }
    public void Prev()
    {
        area.Prev();
    }
    public void Action()
    {
        area.Action();
    }
    public void Action2()
    {
        area.Action2();
    }
    public void Info(bool isOn)
    {
        infoSignal.SetOn(isOn);
    }
   
}
