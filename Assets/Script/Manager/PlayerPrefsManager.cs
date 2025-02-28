using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string ItemsKey = "SavedItems";
    private const string GoldKey = "PlayerGold";
    private const string LanguageKey = "SelectedLanguage";
    private const string ChapterInfoKey = "ChapterInfo";
    public int Gold { get; private set; }

    // 아이템 정보를 저장하는 구조체
    public struct Item
    {
        public int Id; // 아이템을 구분하는 고유한 번호
        public int Type; // 아이템의 종류 번호 - 장비, 소비 아이템 등

        public override string ToString()
        {
            return $"{Id}:{Type}";
        }

        public static Item FromString(string data)
        {
            string[] parts = data.Split(':');
            if (parts.Length == 2 &&
                int.TryParse(parts[0], out int id) &&
                int.TryParse(parts[1], out int type))
            {
                return new Item { Id = id, Type = type };
            }

            return default;
        }
    }

    HashSet<Item> items = new HashSet<Item>();

    // Start는 MonoBehaviour가 생성된 후 Update가 실행되기 전에 한 번 호출됩니다.
    void Start()
    {
        //LoadGold();
    }

    public int LastSavedItemCheck()
    {
        int LastitemID = GetLastItemNumber();
        return LastitemID + 1;
    }

    public void SaveItem(int itemId, int itemType)
    {
        HashSet<Item> savedItems = LoadItems();

        Item newItem = new Item { Id = itemId, Type = itemType };

        if (savedItems.Contains(newItem))
        {
            Debug.Log($"Item {itemId} is already saved.");
            return;
        }

        savedItems.Add(newItem);
        PlayerPrefs.SetString(ItemsKey, string.Join(",", savedItems));
        PlayerPrefs.Save();

        Debug.Log($"Item {itemId} saved successfully.");
    }

    public HashSet<Item> GetItemListInfo()
    {
        if (items.Count == 0)
            LoadItems();

        foreach (Item itemInfo in items)
        {
            Debug.Log("저장된 아이템 ID : " + itemInfo.Id + " 타입 : " + itemInfo.Type);
        }

        return items;
    }

    HashSet<Item> LoadItems()
    {
        string savedData = PlayerPrefs.GetString(ItemsKey, string.Empty);

        if (string.IsNullOrEmpty(savedData))
        {
            return new HashSet<Item>();
        }

        string[] itemStrings = savedData.Split(',');

        foreach (string itemString in itemStrings)
        {
            Item item = Item.FromString(itemString);
            if (item.Id != 0 || item.Type != 0)
            {
                items.Add(item);
            }
        }

        return items;
    }

    public int GetLastItemNumber()
    {
        HashSet<Item> savedItems = LoadItems();

        if (savedItems.Count == 0)
        {
            Debug.LogWarning("저장된 아이템이 없습니다.");
            return -1;
        }

        int maxItemNumber = int.MinValue;

        foreach (Item item in savedItems)
        {
            Debug.Log("저장된 아이템 ID : " + item.Id);

            if (item.Id > maxItemNumber)
            {
                maxItemNumber = item.Id;
            }
        }

        Debug.Log($"마지막으로 저장된 아이템 번호: {maxItemNumber}");
        return maxItemNumber;
    }

    public void RemoveItem(int itemId)
    {
        HashSet<Item> savedItems = LoadItems();

        Item itemToRemove = new Item { Id = itemId, Type = 0 };
        bool removed = false;
        foreach (Item item in savedItems)
        {
            if (item.Id == itemId)
            {
                removed = savedItems.Remove(item);
                break;
            }
        }

        if (removed)
        {
            PlayerPrefs.SetString(ItemsKey, string.Join(",", savedItems));
            PlayerPrefs.Save();
            Debug.Log($"아이템 {itemId} 제거 완료.");
        }
        else
        {
            Debug.LogWarning($"아이템 {itemId}을 찾을 수 없습니다.");
        }
    }

    // 골드 추가
    public void AddGold(int amount)
    {
        Gold += amount;
        SaveGold();
    }

    // 골드 사용
    public bool SpendGold(int amount)
    {
        if (Gold >= amount)
        {
            Gold -= amount;
            SaveGold();
            return true;
        }
        return false;
    }

    // 골드 저장
    private void SaveGold()
    {
        PlayerPrefs.SetInt(GoldKey, Gold);
        PlayerPrefs.Save();
    }

    // 골드 불러오기
    public void LoadGold()
    {
        Gold = PlayerPrefs.GetInt(GoldKey, 0);
        Debug.Log("현재 골드 : " + Gold);
    }

    // 골드 초기화
    public void ResetGold()
    {
        PlayerPrefs.DeleteKey(GoldKey);
        Gold = 0;
    }

    // 챕터 번호와 진행 여부 저장
    public void SaveChapterInfo(int chapterNumber, bool isInProgress)
    {
        string data = $"{chapterNumber}:{(isInProgress ? 1 : 0)}";
        PlayerPrefs.SetString(ChapterInfoKey, data);
        PlayerPrefs.Save();
        Debug.Log($"저장된 챕터 정보 -> 챕터: {chapterNumber}, 진행 중: {isInProgress}");
    }

    // 챕터 번호와 진행 여부 불러오기
    public void LoadChapterInfo(out int chapterNumber, out bool isInProgress)
    {
        string data = PlayerPrefs.GetString(ChapterInfoKey, "1:0"); // 기본값: 1챕터, 진행 중 아님
        string[] parts = data.Split(':');

        if (parts.Length == 2 && int.TryParse(parts[0], out chapterNumber) && int.TryParse(parts[1], out int progress))
        {
            isInProgress = progress == 1;
        }
        else
        {
            chapterNumber = 1;
            isInProgress = false;
        }

        Debug.Log($"불러온 챕터 정보 -> 챕터: {chapterNumber}, 진행 중: {isInProgress}");
    }

    // 챕터 정보 초기화
    public void ResetChapterInfo()
    {
        PlayerPrefs.DeleteKey(ChapterInfoKey);
        Debug.Log("챕터 정보가 초기화되었습니다.");
    }

    public void SaveLanguage(string language)
    {
        PlayerPrefs.SetString(LanguageKey, language);
        PlayerPrefs.Save();
    }

    public string LoadLanguage(string language)
    {
        return PlayerPrefs.GetString(LanguageKey, language);
    }

    void Update()
    {
    }
}
