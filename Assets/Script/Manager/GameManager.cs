using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public enum eScene
{
    LOBBY,
    INGAME,
}

class MyCharState
{
    int Level;
    int Exp;
    int HP;
    int Att;
    float Att_Speed;
    int Def;
}

public class GameManager : MonoBehaviour
{
    // �� �κ��丮�� ��� �ִ� ������ ����
    // ���� �ؾ� �� ����Ʈ ����
    // �� ĳ���� ���� ����

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager prefsManager;
    public ItemIconResource itemIconResource;
    public ShopIconResource shopIconResource;
    public LocalizationManager localMng;

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList = new List<ItemInfo>();

    // Lobby �� ������ �ִ� �˾� UI

    Dictionary<UIElement, RefreshElement> UI_ElementList 
        = new Dictionary<UIElement, RefreshElement>();

    //private GameObject inventoryPopup;
    //private GameObject iteminfoPopup;
    //private GameObject dungeonSelectPopup;
    //private GameObject questPopup;
    //private GameObject shopPopup;
    
    
    public static GameManager Instance { get; private set; }

    //public PopupInstance popup_Inst;

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
        string language = prefsManager.LoadLanguage("jp");
        Debug.Log("Select Language : " + language);

        // 시나리오 정보를 읽어와서 현재 읽어들어야 할 
        // 시나리오 정보가 있다면 팝업을 띄운다.
        int chapter;
        bool progress;
        prefsManager.LoadChapterInfo(out chapter,out progress);
        if(progress == false)
        {
            Debug.Log("대사창 열기");
            PopupInstance.Instance.ScenarioPopupOpen();
        }
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

    public Sprite GetShoptypeSprite(int itemID)
    {
        int icon = 0;
        switch (itemID)
        {
            case 101: icon = 0; break;
            case 102: icon = 1; break;
        }

        return shopIconResource.iconArray[icon];
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
