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
    // 한 인벤토리에 들어 있는 아이템 정보
    // 싱글톤 패턴으로 하나만 존재하도록 처리
    // 내 캐릭터 상태 정보

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager prefsManager;
    public ItemIconResource itemIconResource;
    public ShopIconResource shopIconResource;
    public PortraitResource portraitResource;
    public LocalizationManager localMng;
    public StoryManager storyManager;    

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList = new List<ItemInfo>();

    // Lobby 에 상시 떠 있는 팝업 UI

    Dictionary<UIElement, RefreshElement> UI_ElementList 
        = new Dictionary<UIElement, RefreshElement>();
        
    public static GameManager Instance { get; private set; }

    //public PopupInstance popup_Inst;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 새로 만든 객체를 파괴
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        
    }

    public void SceneInit()
    {

        string language = prefsManager.LoadLanguage("jp");
        Debug.Log("Select Language : " + language);

        
        storyManager.DoNextStory();
        
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
    
    // 갱신하고 싶은 UI 처리 함수
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

    public Sprite GetPortraitImage(int type)
    {
        return portraitResource.portraitArray[type];
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