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
    // �� �κ��丮�� ��� �ִ� ������ ����
    // ���� �ؾ� �� ����Ʈ ����
    // �� ĳ���� ���� ����

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager prefsManager;
    public ItemIconResource itemIconResource;

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList = new List<ItemInfo>();

    // Lobby �� ������ �ִ� �˾� UI

    Dictionary<UIElement, RefreshElement> UI_ElementList 
        = new Dictionary<UIElement, RefreshElement>();

    private GameObject inventoryPopup;
    public GameObject item_prefab; // �κ��丮 ��ũ�ѿ� ǥ���� ������ ������
    public RectTransform content; // �������� ����� �θ� ������Ʈ
    private GameObject iteminfoPopup;
    private GameObject dungeonSelectPopup;
    private GameObject questPopup;
    public static GameManager Instance { get; private set; }

    public PopupInstance popup_Inst;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // ���� �ν��Ͻ��� ������ ���� ������ ���� �ı�
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    public void SetElementToManager(UIElement element, RefreshElement uiObject)
    {
        if (UI_ElementList.ContainsKey(element) == false)
        {
            UI_ElementList.Add(element, uiObject);
            Debug.Log("UI Element Add Manager : " + element);
        }
        else
        {
            UI_ElementList[element] = uiObject;
            Debug.Log("UI Element exist : " + element);
        }
    }
    // �����ϰ� ���� UI ó�� �Լ�
    public void RefreshUIElement(UIElement element)
    {
        UI_ElementList[element].RefreshUI();
    }

    public void ResetPopupInstance()
    {
        if (currenScene == eScene.LOBBY)
        {
            GameObject popinst = GameObject.Find("PopupInst");
            popup_Inst = popinst.GetComponent<PopupInstance>();

            inventoryPopup = popup_Inst.inventoryPopup;
            if (inventoryPopup != null) inventoryPopup.SetActive(false);

            content = popup_Inst.inventoryListContent.GetComponent<RectTransform>();

            iteminfoPopup = popup_Inst.iteminfoPopup;
            if (iteminfoPopup != null) iteminfoPopup.SetActive(false);

            dungeonSelectPopup = popup_Inst.DungeonSelectPopup;
            if (dungeonSelectPopup != null) dungeonSelectPopup.SetActive(false);

            questPopup = popup_Inst.questPopup;
            if (questPopup != null) questPopup.SetActive(false);

            Debug.Log("current Scene Lobby");
        }
        else if (currenScene == eScene.INGAME)
        {
            Debug.Log("current Scene Ingame");
        }
    }

    public Sprite GetItemTypeSprite(int type)
    {
        int icon = 0;
        switch (type)
        {
            case 101: icon = 0; break;
            case 102: icon = 1; break;
            case 103: icon = 2; break;
            case 104: icon = 3; break;
            case 105: icon = 4; break;
            case 106: icon = 5; break;
            case 107: icon = 6; break;
            case 108: icon = 7; break;
            case 109: icon = 8; break;
            case 110: icon = 9; break;
            default: icon = 0; break;
        }

        return itemIconResource.iconArray[icon];
    }

    public void RefreshInventory()
    {
        HashSet<PlayerPrefsManager.Item> inventoryList = prefsManager.GetItemListInfo();
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        
        foreach (PlayerPrefsManager.Item item in inventoryList)
        {
            if (item.Type == 0) continue;

            GameObject itemobj = Instantiate(item_prefab);
            itemobj.transform.GetChild(0).
                GetComponent<Image>().sprite = GetItemTypeSprite(item.Type);

            // �������� ���� ��ȣ ����
            itemobj.GetComponent<ItemInfoBtn>().SetItemType(item.Type);
            // ������ ���Ÿ� ���� ������ ���� ��ȣ ����
            itemobj.GetComponent<ItemInfoBtn>().SetItemOwnId(item.Id);

            ItemInfo info = csvloadManager.FindItemInfo(item.Type);
            itemobj.transform.GetChild(0).GetChild(0).
                GetComponent<Text>().text = info.name;

            itemobj.transform.parent = content;

            itemobj.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public void InventoryPopupOpen()
    {
        // 2�� ������ ���� �׽�Ʈ
        //prefsManager.RemoveItem(2);

        // csv���� �Ŵ������� ��������
        List<ItemInfo> itemList = csvloadManager.GetItemList();

        foreach (ItemInfo info in itemList)
        {
            //Debug.Log("item_number : " + info.item_number +" ability : "+ info.ability);
        }

        

        // playerPrefs�� ���� ������ ������ ���� ��������
        HashSet<PlayerPrefsManager.Item> inventoryList = prefsManager.GetItemListInfo();

        /*foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }*/

        if (content.childCount <= 0)
        {
            foreach (PlayerPrefsManager.Item item in inventoryList)
            {
                if (item.Type == 0) continue;

                GameObject itemobj = Instantiate(item_prefab);
                itemobj.transform.GetChild(0).
                    GetComponent<Image>().sprite = GetItemTypeSprite(item.Type);

                // �������� ���� ��ȣ ����
                itemobj.GetComponent<ItemInfoBtn>().SetItemType(item.Type);
                // ������ ���Ÿ� ���� ������ ���� ��ȣ ����
                itemobj.GetComponent<ItemInfoBtn>().SetItemOwnId(item.Id);

                ItemInfo info = csvloadManager.FindItemInfo(item.Type);
                itemobj.transform.GetChild(0).GetChild(0).
                    GetComponent<Text>().text = info.name;

                itemobj.transform.parent = content;

                itemobj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // ���� ������ �������� csv������ ����

        // UI ������ �˾� �����ϱ�

        inventoryPopup.SetActive(true);
    }

    public void DungeonSelectPopupOpen()
    {
        dungeonSelectPopup.SetActive(true);
    }

    public void AddItem(GameObject item)
    {
        // PlayerPrefs�� ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
