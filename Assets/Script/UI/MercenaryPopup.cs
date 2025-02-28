using UnityEngine;

public class MercenaryPopup : RefreshElement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        element = UIElement.MERCENARY;
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
