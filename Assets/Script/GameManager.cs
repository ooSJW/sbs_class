using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public enum eScene
{
    LOBBY,
    INGAME,
}

class InventoryItemInfo
{

}

class MyCharState
{
    int Level;
    int Exp;
}

public class GameManager : MonoBehaviour
{
    // 내 인벤토리에 들어 있는 아이템 정보
    // 내가 해야 할 퀘스트 정보
    // 내 캐릭터 현재 정보

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager prefsManager;
    public ItemIconResource itemIconResource;

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList = new List<ItemInfo>();

    // Lobby 에 가지고 있는 팝업 UI
    private GameObject inventoryPopup;
    public GameObject item_prefab;
    public RectTransform content;
    private GameObject dungeonSelectPopup;
    private GameObject questPopup;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if(currenScene == eScene.LOBBY)
        {
            GameObject popinst = GameObject.Find("PopupInst");
            
            inventoryPopup = popinst.GetComponent<PopupInstance>().inventoryPopup;
            if (inventoryPopup != null) inventoryPopup.SetActive(false);
            
            dungeonSelectPopup = popinst.GetComponent<PopupInstance>().DungeonSelectPopup;
            if (dungeonSelectPopup != null) dungeonSelectPopup.SetActive(false);

            questPopup = popinst.GetComponent<PopupInstance>().questPopup;
            if (questPopup != null) questPopup.SetActive(false);
            
            Debug.Log("current Scene Lobby");
        }
        else if(currenScene == eScene.INGAME)
        {
            Debug.Log("current Scene Ingame");
        }

    }

    public void InventoryPopupOpen()
    {
        // csv정보 매니저에서 가져오기
        List<ItemInfo> itemList = csvloadManager.GetItemList();

        foreach (ItemInfo info in itemList)
        {
            Debug.Log("item_number : " + info.item_number +" ability : "+ info.ability);
        }

        

        // playerPrefs에 내가 소유한 아이템 정보 가져오기
        HashSet<PlayerPrefsManager.Item> inventoryList = prefsManager.GetItemListInfo();

        /*foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }*/

        if (content.childCount <= 0)
        {
            foreach (PlayerPrefsManager.Item item in inventoryList)
            {
                int icon = 0;
                switch(item.Type)
                {
                    case 101: icon = 0; break;
                    case 201: icon = 1; break;
                    default: icon = 0; break;
                }

                GameObject itemobj = Instantiate(item_prefab);
                itemobj.transform.GetChild(0).
                    GetComponent<Image>().sprite = itemIconResource.iconArray[icon];

                ItemInfo info = csvloadManager.FindItemInfo(item.Type);
                itemobj.transform.GetChild(1).
                    GetComponent<Text>().text = info.name;

                itemobj.transform.parent = content;

                itemobj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // 내가 소유한 아이템을 csv정보로 셋팅

        // UI 아이템 팝업 연동하기

        inventoryPopup.SetActive(true);
    }

    public void DungeonSelectPopupOpen()
    {
        dungeonSelectPopup.SetActive(true);
    }

    public void AddItem(GameObject item)
    {
        // PlayerPrefs에 아이템 저장
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
