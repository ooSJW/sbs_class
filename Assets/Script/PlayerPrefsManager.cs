using System.Collections.Generic;
using UnityEngine;

public partial class PlayerPrefsManager : MonoBehaviour // Data Field
{
    private const string itemKey = "SavedItems";
    public struct Item
    {
        public int number; // 아이템 저장번호
        public int id; // 아이템 고유 번호

        public override string ToString()
        {
            return $"{number}:{id}";
        }

        public static Item FromString(string data)
        {
            string[] parts = data.Split(':');
            if (parts.Length == typeof(Item).GetFields().Length
                &&
                int.TryParse(parts[0], out int idValue)
                &&
                int.TryParse(parts[1], out int numberValue))
            {
                return new Item { number = numberValue, id = idValue };
            }
            return default;
        }
    }

    private HashSet<Item> itemHashSet = new HashSet<Item>();
}
public partial class PlayerPrefsManager : MonoBehaviour // Initialize
{
    private void Allocate()
    {

    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {

    }
}
public partial class PlayerPrefsManager : MonoBehaviour // 
{
    public int LastSavedItemCheck()
    {
        int LastitemID = GetLastItemNumber();
        return LastitemID + 1;
    }

    public void SaveItem(int itemId, int itemType)
    {
        HashSet<Item> savedItems = LoadItems();

        Item newItem = new Item { number = itemId, id = itemType };

        if (savedItems.Contains(newItem))
        {
            Debug.Log($"Item {itemId} is already saved.");
            return;
        }

        savedItems.Add(newItem);
        PlayerPrefs.SetString(itemKey, string.Join(",", savedItems));
        PlayerPrefs.Save();

        Debug.Log($"Item {itemId} saved successfully.");
    }

    public HashSet<Item> GetItemListInfo()
    {
        if (itemHashSet.Count == 0)
            LoadItems();

        foreach (Item itemInfo in itemHashSet)
        {
            Debug.Log("saved itemID : " + itemInfo.number);
        }

        return itemHashSet;
    }

    HashSet<Item> LoadItems()
    {
        string savedData = PlayerPrefs.GetString(itemKey, string.Empty);

        if (string.IsNullOrEmpty(savedData))
        {
            return new HashSet<Item>();
        }

        string[] itemStrings = savedData.Split(',');


        foreach (string itemString in itemStrings)
        {
            Item item = Item.FromString(itemString);
            if (item.number != 0 || item.id != 0)
            {
                itemHashSet.Add(item);
            }
        }

        return itemHashSet;
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
            Debug.Log("saved itemID : " + item.number);

            if (item.number > maxItemNumber)
            {
                maxItemNumber = item.number;
            }
        }

        Debug.Log($"Last saved item number: {maxItemNumber}");
        return maxItemNumber;
    }
}