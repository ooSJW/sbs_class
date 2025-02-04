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
    // TODO : �κ��丮, ����Ʈ, ĳ���� ����

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
            // TODO : ������ ���� csv ���Ͽ��� �о����
            List<ItemInfo> itemInfoList = csvLoadManager.GetItemInfo();
            // TODO : ui ������ �˾� ����
            // TODO : playerPrefs���� ������ ���� ��������, �ش� ������ ������ csv���� ã�� ���� ����
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