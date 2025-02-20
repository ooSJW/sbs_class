using UnityEngine;

public class ShopInfoBtn : MonoBehaviour
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

    public void ShopInfoShowBtn()
    {
        Debug.Log("ItemType: " + ItemType);
        Debug.Log("OwnID: " + Id);

        //GameObject ShowObj = PopupInstance.Instance.shopitemPopup;
        GameObject ShowObj = PopupInstance.Instance.GetPopup(popup_index.SHOP_ITEM_POPUP);
        
        PopupInstance.ShowPopup(ShowObj, () => {

            ShopInfoPopup popup = ShowObj.GetComponent<ShopInfoPopup>();
            popup.SetItemInfo(ItemType, Id);
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
