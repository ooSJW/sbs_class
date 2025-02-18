using UnityEngine;

public class InventoryPopup : RefreshElement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        element = UIElement.INVENTORY;
        SetElementToManager();
    }

    protected override void SetElementToManager()
    {
        base.SetElementToManager();
    }

    override public void RefreshUI()
    {
        PopupInstance.Instance.RefreshInventory();
    }

    public void CloseBtn()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
