using UnityEngine;

public class OptionPopup : RefreshElement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        element = UIElement.OPTION;
        SetElementToManager();
    }

    protected override void SetElementToManager()
    {
        base.SetElementToManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
