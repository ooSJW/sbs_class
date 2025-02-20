using UnityEngine;

public class ItemInfoBtn : MonoBehaviour
{
    private int Id;
    private int ItemType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetItemType(int type)
    {
        ItemType = type;
    }

    public void SetItemOwnId(int Id)
    {
        this.Id = Id;
    }

    public void ItemInfoShowBtn()
    {
        Debug.Log("ItemType: " + ItemType);
        Debug.Log("OwnID: " + Id);

        //GameObject ShowObj = PopupInstance.Instance.inventoryitemPopup;
        GameObject ShowObj = PopupInstance.Instance.GetPopup(popup_index.INVEN_ITEM_POPUP);


        PopupInstance.ShowPopup(ShowObj, () => {

            ItemInfoPopup popup = ShowObj.GetComponent<ItemInfoPopup>();
            popup.SetItemInfo(ItemType, Id);
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
