using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupInstance : MonoBehaviour
{
    // Lobby 에 가지고 있는 팝업 UI
    public GameObject inventoryPopup;
    public GameObject inventoryitemPopup;
    public GameObject shopPopup;
    public GameObject shopitemPopup;
    public GameObject dungeonSelectPopup;
    public GameObject questPopup;

    public RectTransform inventoryListcontent; // 프리팹이 연결될 부모 오브젝트
    public GameObject item_prefab; // 인벤토리 스크롤에 표시할 아이템 프리팹
    public RectTransform shopListcontent;
    public GameObject shop_item_prefab;

    private GameManager gameMng_Instance;

    public static PopupInstance Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameMng_Instance = GameManager.Instance;

        ResetPopupInstance();
    }

    void ResetPopupInstance()
    {
        if (inventoryPopup != null) inventoryPopup.SetActive(false);
        if (inventoryitemPopup != null) inventoryitemPopup.SetActive(false);
        if (shopPopup != null) shopPopup.SetActive(false);
        if (shopitemPopup != null) shopitemPopup.SetActive(false);
        if (dungeonSelectPopup != null) dungeonSelectPopup.SetActive(false);
        if (questPopup != null) questPopup.SetActive(false);
        
    }

    public void DungeonSelectPopupOpen()
    {
        dungeonSelectPopup.SetActive(true);
    }

    public void RefreshInventory()
    {
        HashSet<PlayerPrefsManager.Item> inventoryList = gameMng_Instance.prefsManager.GetItemListInfo();
        foreach (Transform child in inventoryListcontent)
        {
            Destroy(child.gameObject);
        }

        foreach (PlayerPrefsManager.Item item in inventoryList)
        {
            if (item.Type == 0) continue;

            GameObject itemobj = Instantiate(item_prefab);
            itemobj.transform.GetChild(0).
                GetComponent<Image>().sprite = gameMng_Instance.GetItemTypeSprite(item.Type);

            // 아이템의 종류 번호 셋팅
            itemobj.GetComponent<ItemInfoBtn>().SetItemType(item.Type);
            // 아이템 제거를 위한 아이템 소유 번호 셋팅
            itemobj.GetComponent<ItemInfoBtn>().SetItemOwnId(item.Id);

            ItemInfo info = gameMng_Instance.csvloadManager.FindItemInfo(item.Type);
            itemobj.transform.GetChild(0).GetChild(0).
                GetComponent<Text>().text = info.name;

            itemobj.transform.parent = inventoryListcontent;

            itemobj.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public void InventoryPopupOpen()
    {
        // 2번 아이템 제거 테스트
        //prefsManager.RemoveItem(2);

        // csv정보 매니저에서 가져오기
        List<ItemInfo> itemList = gameMng_Instance.csvloadManager.GetItemList();

        foreach (ItemInfo info in itemList)
        {
            //Debug.Log("item_number : " + info.item_number +" ability : "+ info.ability);
        }



        // playerPrefs에 내가 소유한 아이템 정보 가져오기
        HashSet<PlayerPrefsManager.Item> inventoryList = gameMng_Instance.prefsManager.GetItemListInfo();

        /*foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }*/

        if (inventoryListcontent.childCount <= 0)
        {
            foreach (PlayerPrefsManager.Item item in inventoryList)
            {
                if (item.Type == 0) continue;

                GameObject itemobj = Instantiate(item_prefab);
                itemobj.transform.GetChild(0).
                    GetComponent<Image>().sprite = gameMng_Instance.GetItemTypeSprite(item.Type);

                // 아이템의 종류 번호 셋팅
                itemobj.GetComponent<ItemInfoBtn>().SetItemType(item.Type);
                // 아이템 제거를 위한 아이템 소유 번호 셋팅
                itemobj.GetComponent<ItemInfoBtn>().SetItemOwnId(item.Id);

                ItemInfo info = gameMng_Instance.csvloadManager.FindItemInfo(item.Type);
                itemobj.transform.GetChild(0).GetChild(0).
                    GetComponent<Text>().text = info.name;

                itemobj.transform.parent = inventoryListcontent;

                itemobj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // 내가 소유한 아이템을 csv정보로 셋팅

        // UI 아이템 팝업 연동하기

        inventoryPopup.SetActive(true);
    }

    public void ShopPopupOpen()
    {
        List<ShopItemInfo> shopinfoList = gameMng_Instance.csvloadManager.GetShopitemInfoList();

        if (shopListcontent.childCount <= 0)
        {

            foreach (ShopItemInfo shopiteminfo in shopinfoList)
            {
                GameObject itemobj = Instantiate(shop_item_prefab);
                itemobj.transform.GetChild(0).
                    GetComponent<Image>().sprite = gameMng_Instance.GetShoptypeSprite(int.Parse(shopiteminfo.itemID));

                //구매 스크립트 정보
                int itemID = int.Parse(shopiteminfo.itemID);
                itemobj.GetComponent<ShopInfoBtn>().SetItemType(itemID);

                ItemInfo info = gameMng_Instance.csvloadManager.FindItemInfo(int.Parse(shopiteminfo.itemID));
                itemobj.transform.GetChild(0).GetChild(0).
                    GetComponent<Text>().text = info.name;

                itemobj.transform.parent = shopListcontent;

                itemobj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        shopPopup.SetActive(true);
    }

    static public void ShowPopup(GameObject showObject, Action SetInfo)
    {
        SetInfo();

        showObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
