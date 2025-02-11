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
        // csv���� �Ŵ������� ��������
        List<ItemInfo> itemList = csvloadManager.GetItemList();

        foreach (ItemInfo info in itemList)
        {
            Debug.Log("item_number : " + info.item_number +" ability : "+ info.ability);
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
