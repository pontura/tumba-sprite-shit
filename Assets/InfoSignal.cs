using UnityEngine;

public class InfoSignal : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text titleField;
    [SerializeField] TMPro.TMP_Text textField;

    static InfoSignal mInstance = null;
    private void Awake()
    {
        mInstance = this;
    }
    public static InfoSignal Instance
    {
        get {  return mInstance; }
    }

    public void SetOn(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
    public void ChangeData(string title, string text)
    {
        print("Change data "  + title + " text: " + text);
        titleField.text = title;
        textField.text = text;
    }
}
