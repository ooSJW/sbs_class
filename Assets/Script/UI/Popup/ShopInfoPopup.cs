using UnityEngine;
using UnityEngine.UI;

public class ShopInfoPopup : MonoBehaviour
{
    int cur_itemtype = 0;
    int cur_itemId = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetItemInfo(int item_type, int itemId)
    {
        cur_itemtype = item_type;
        cur_itemId = itemId;
        transform.GetChild(0).GetComponent<Image>().sprite =
            GameManager.Instance.GetShoptypeSprite(item_type);
        //transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
        //    GameManager.Instance.csvloadManager.FindItemInfo(item_type).name;
    }

    public void BuyItem()
    {
        //cur_itemId 추가
        //GameManager.Instance.prefsManager.RemoveItem(cur_itemId);
        //gold감소
        //int add_gold = GameManager.Instance.csvloadManager.
        //    FindItemInfo(cur_itemtype).sellprice;
        int buy_gold = GameManager.Instance.csvloadManager.FindShopItemInfo(cur_itemtype).price;

        // TODO 현재 내 Gold를 검사해서 구매 할 수 있는지 검사

        GameManager.Instance.prefsManager.AddGold(-buy_gold);

        int newitemID = GameManager.Instance.prefsManager.LastSavedItemCheck();
        GameManager.Instance.prefsManager.SaveItem(newitemID, cur_itemtype);


        //팝업 닫기
        CloseDlg();
        
        //로비 UI 갱신
        GameManager.Instance.RefreshUIElement(UIElement.TOPUI);
    }

    public void CloseDlg()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
