using UnityEngine;
using TMPro;
using Unity.Android.Gradle;

public class TopUI : RefreshElement
{
    PlayerPrefsManager prefs_mng;

    public TextMeshProUGUI goldUI_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        element = UIElement.TOPUI;
        SetElementToManager();

        prefs_mng = GameObject.Find("GameManager").GetComponent<GameManager>().prefsManager;
        prefs_mng.LoadGold();
        //prefs_mng.AddGold(5000);
        //prefs_mng.ResetGold();
        goldUI_text.text = prefs_mng.Gold.ToString("N0");
    }

    protected override void SetElementToManager()
    {
        base.SetElementToManager();
    }

    override public void RefreshUI()
    {
        prefs_mng.LoadGold();
        //prefs_mng.AddGold(5000);
        //prefs_mng.ResetGold();
        goldUI_text.text = prefs_mng.Gold.ToString("N0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
