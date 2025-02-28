using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public enum popup_index
{
    INVEN_POPUP = 0,        // 인벤토리 팝업
    INVEN_ITEM_POPUP,       // 인벤토리 아이템 팝업
    SHOP_POPUP,             // 상점 팝업
    SHOP_ITEM_POPUP,        // 상점 아이템 팝업
    DUNGEON_SELECT_POPUP,   // 던전 선택 팝업
    QUEST_POPUP,            // 퀘스트 팝업
    OPTION_POPUP,           // 옵션 팝업
    MERCENARY_POPUP,        // 용병 팝업
    SCENARIO_POPUP,         // 시나리오 팝업
}

public class PopupInstance : MonoBehaviour
{
    // 로비에 존재하는 팝업 UI
    //public GameObject inventoryPopup;         // 인벤토리 팝업
    //public GameObject inventoryitemPopup;     // 인벤토리 아이템 팝업
    //public GameObject shopPopup;              // 상점 팝업
    //public GameObject shopitemPopup;          // 상점 아이템 팝업
    //public GameObject dungeonSelectPopup;     // 던전 선택 팝업
    //public GameObject questPopup;             // 퀘스트 팝업
    //public GameObject optionPopup;            // 옵션 팝업

    public GameObject[] popups;                 // 팝업 배열

    public RectTransform inventoryListcontent;  // 인벤토리 리스트의 부모 컴포넌트
    public GameObject item_prefab;              // 인벤토리 스크롤에 표시할 아이템 프리팹
    public RectTransform shopListcontent;       // 상점 리스트의 부모 컴포넌트
    public GameObject shop_item_prefab;         // 상점 아이템 프리팹

    private GameManager gameMng_Instance;

    public static PopupInstance Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject GetPopup(popup_index index)
    {
        return popups[(int)index];
    }

    // Start는 MonoBehaviour가 생성된 후 첫 Update 실행 전에 한 번 호출됩니다.
    void Start()
    {
        gameMng_Instance = GameManager.Instance;

        ResetPopupInstance();
    }

    void ResetPopupInstance()
    {
        /*
        if (inventoryPopup != null) inventoryPopup.SetActive(false);
        if (inventoryitemPopup != null) inventoryitemPopup.SetActive(false);
        if (shopPopup != null) shopPopup.SetActive(false);
        if (shopitemPopup != null) shopitemPopup.SetActive(false);
        if (dungeonSelectPopup != null) dungeonSelectPopup.SetActive(false);
        if (questPopup != null) questPopup.SetActive(false);
        */

        for (int i = 0; i < popups.Length; i++)
        {
            if (popups[i] != null) popups[i].SetActive(false);
        }
    }

    public void DungeonSelectPopupOpen()
    {
        //dungeonSelectPopup.SetActive(true);
        popups[(int)popup_index.DUNGEON_SELECT_POPUP].SetActive(true);
    }

    public void OptionPopupOpen()
    {
        popups[(int)popup_index.OPTION_POPUP].SetActive(true);
    }

    public void MercenaryPopupOpen()
    {
        popups[(int)popup_index.MERCENARY_POPUP].SetActive(true);
    }

    public void ScenarioPopupOpen()
    {
        popups[(int)popup_index.SCENARIO_POPUP].SetActive(true);
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

            // 아이템의 타입 번호 설정
            itemobj.GetComponent<ItemInfoBtn>().SetItemType(item.Type);
            // 플레이어 소유 아이템의 고유 번호 설정
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
        // 2번 아이템 삭제 테스트
        //prefsManager.RemoveItem(2);

        // CSV에서 로드된 아이템 리스트
        List<ItemInfo> itemList = gameMng_Instance.csvloadManager.GetItemList();

        foreach (ItemInfo info in itemList)
        {
            //Debug.Log("아이템 번호 : " + info.item_number + " 능력 : " + info.ability);
        }

        // PlayerPrefs에 저장된 플레이어의 아이템 리스트 가져오기
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

                // 아이템의 타입 번호 설정
                itemobj.GetComponent<ItemInfoBtn>().SetItemType(item.Type);
                // 플레이어 소유 아이템의 고유 번호 설정
                itemobj.GetComponent<ItemInfoBtn>().SetItemOwnId(item.Id);

                ItemInfo info = gameMng_Instance.csvloadManager.FindItemInfo(item.Type);
                itemobj.transform.GetChild(0).GetChild(0).
                    GetComponent<Text>().text = info.name;

                itemobj.transform.parent = inventoryListcontent;

                itemobj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // 현재 보유한 아이템을 CSV 데이터와 비교

        // UI 팝업창 표시하기

        //inventoryPopup.SetActive(true);
        popups[(int)popup_index.INVEN_POPUP].SetActive(true);
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

                // 상점 스크립트 설정
                int itemID = int.Parse(shopiteminfo.itemID);
                itemobj.GetComponent<ShopInfoBtn>().SetItemType(itemID);

                ItemInfo info = gameMng_Instance.csvloadManager.FindItemInfo(int.Parse(shopiteminfo.itemID));
                itemobj.transform.GetChild(0).GetChild(0).
                    GetComponent<Text>().text = info.name;

                itemobj.transform.parent = shopListcontent;

                itemobj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        //shopPopup.SetActive(true);
        popups[(int)popup_index.SHOP_POPUP].SetActive(true);
    }

    static public void ShowPopup(GameObject showObject, Action SetInfo)
    {
        SetInfo();

        showObject.SetActive(true);
    }

    // Update는 매 프레임마다 호출됩니다.
    void Update()
    {
        
    }
}