using UnityEngine;

public class LobbyBtn : MonoBehaviour
{
    public PopupInstance popup_inst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void InventoryPopupOpen()
    {
        popup_inst.InventoryPopupOpen();
    }

    public void ShopPopupOpen()
    {
        popup_inst.ShopPopupOpen();
    }

    public void DungeonSelectPopupOpen()
    {
        popup_inst.DungeonSelectPopupOpen();
    }

    public void OptionPopupOpen()
    {
        popup_inst.OptionPopupOpen();
    }

    public void MercenaryPopupOpen()
    {
        popup_inst.MercenaryPopupOpen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
