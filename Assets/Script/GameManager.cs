using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static PlayerPrefsManager;

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
    public PlayerPrefsManager playerPrefsManager;
    SceneName currentScene = SceneName.Lobby;

    private List<ItemInfo> itemInfoList = new List<ItemInfo>();

    public GameObject itemPrefab;
    // Lobby Popup UI List
    [Header("LobbyScene")]
    public GameObject inventoryPopup;
    public GameObject questPopup;
    public RectTransform content;
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
            // TODO : ui ������ �˾� ����
            // TODO : playerPrefs���� ������ ���� ��������, �ش� ������ ������ csv���� ã�� ���� ����
            List<ItemInfo> itemInfoList = csvLoadManager.GetItemInfo();
            HashSet<Item> inventoryHashSet = playerPrefsManager.GetItemListInfo();
            foreach (Transform child in content)
            {
                Destroy(child);
            }
            foreach (Item item in inventoryHashSet)
            {
                GameObject itemObject = Instantiate(itemPrefab, content);
                itemObject.transform.localScale = Vector3.one;
            }
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