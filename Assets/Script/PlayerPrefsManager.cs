using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string ItemsKey = "SavedItems";
    private const string GoldKey = "SavedGold";
    public int Gold { get; private set; }
    // �������� �����ϴ� ����ü
    public struct Item
    {
        public int Id; // ���� �����ϰ� �ִ� ������ ��ȣ
        public int Type; // ������ ���� ��ȣ - ������, �������� �ɷ�ġ

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGold();
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
            Debug.Log("saved itemID : " + itemInfo.Id + " type : " + itemInfo.Type);
        }

        return items;
    }

    HashSet<Item> LoadItems()
    {
        // ItemsKey = "SavedItems";
        string savedData = PlayerPrefs.GetString(ItemsKey, string.Empty);

        Debug.Log("saveditemLowinfo : " + savedData);

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
            Debug.LogWarning("No items are saved.");
            return -1;
        }

        int maxItemNumber = int.MinValue;

        foreach (Item item in savedItems)
        {
            Debug.Log("saved itemID : " + item.Id);

            if (item.Id > maxItemNumber)
            {
                maxItemNumber = item.Id;
            }
        }

        Debug.Log($"Last saved item number: {maxItemNumber}");
        return maxItemNumber;
    }

    // ��� ȹ��
    public void AddGold(int amount)
    {
        Gold += amount;
        SaveGold();
    }

    // ��� ���
    public bool SpendGold(int amount)
    {
        if (Gold >= amount)
        {
            Gold = amount;
            SaveGold();
            return true;
        }
        return false;
    }

    // ��� ����
    private void SaveGold()
    {
        PlayerPrefs.SetInt(GoldKey, Gold);
        PlayerPrefs.Save();
    }

    // ��� �ҷ�����
    private void LoadGold()
    {
        Gold = PlayerPrefs.GetInt(GoldKey, 0);
    }

    public void ResetGold()
    {
        PlayerPrefs.DeleteKey(GoldKey);
        Gold = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
