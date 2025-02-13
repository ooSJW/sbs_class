using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPopup : MonoBehaviour
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
            GameManager.Instance.GetItemTypeSprite(item_type);
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
            GameManager.Instance.csvloadManager.FindItemInfo(item_type).name;
    }

    public void RemoveItem()
    {
        //cur_itemId 제거
        GameManager.Instance.prefsManager.RemoveItem(cur_itemId);
        //gold획득
        int add_gold = GameManager.Instance.csvloadManager.
            FindItemInfo(cur_itemtype).sellprice;
        GameManager.Instance.prefsManager.AddGold(add_gold);
        //팝업 닫기
        CloseDlg();
        //인벤토리 팝업의 아이템 목록 갱신
        GameManager.Instance.RefreshUIElement(UIElement.INVENTORY);
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
