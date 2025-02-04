using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum SceneName
{
    Title,
    Lobby,
    InGame,
}

public class InvectoryItemInfo
{

}
public class MyCharacterStat
{
    int level;
    int exp;
}
public partial class GameManager : MonoBehaviour // Data Field
{
    // TODO : 인벤토리, 퀘스트, 캐릭터 정보

    public CsvLoadManager csvLoadManager;

    SceneName currentScene = SceneName.Lobby;

    private List<ItemInfo> itemInfoList = new List<ItemInfo>();

    // Lobby Popup UI List
    [Header("LobbyScene")]
    public GameObject inventoryPopup;
    public GameObject questPopup;
}
public partial class GameManager : MonoBehaviour // Property
{
    public void AddItem(GameObject item)
    {

    }

    public void OnoffInventory()
    {
        bool isActive = inventoryPopup.activeSelf;
        if (!isActive)
        {
            // TODO : 아이템 정보 csv 파일에서 읽어오기
            List<ItemInfo> itemInfoList = csvLoadManager.GetItemInfo();
            // TODO : ui 아이템 팝업 연동
            // TODO : playerPrefs에서 아이템 정보 가져오기, 해당 아이템 정보를 csv에서 찾아 세팅 ㄱㄱ
        }
        inventoryPopup.SetActive(!isActive);
    }
}

public partial class GameManager : MonoBehaviour // main
{
    private void OnEnable()
    {
        switch (currentScene)
        {
            case SceneName.Lobby:
                inventoryPopup = GameObject.Find("Inventory");
                inventoryPopup.SetActive(false);
                break;
            case SceneName.InGame:

                break;
            default:
                print("Default");
                break;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }
}