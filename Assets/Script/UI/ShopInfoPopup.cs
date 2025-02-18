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
        //cur_itemId �߰�
        //GameManager.Instance.prefsManager.RemoveItem(cur_itemId);
        //gold����
        //int add_gold = GameManager.Instance.csvloadManager.
        //    FindItemInfo(cur_itemtype).sellprice;
        GameManager.Instance.prefsManager.AddGold(0);
        //�˾� �ݱ�
        CloseDlg();
        
        //�κ� UI ����
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
