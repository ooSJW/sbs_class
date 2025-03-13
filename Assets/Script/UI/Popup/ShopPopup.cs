using UnityEngine;

public class ShopPopup : RefreshElement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        element = UIElement.SHOP;
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
