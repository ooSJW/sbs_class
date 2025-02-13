using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string ItemsKey = "SavedItems";
    private const string GoldKey = "PlayerGold";

    public int Gold { get; private set; }

    // 아이템을 저장하는 구조체
    public struct Item
    {
        public int Id; // 내가 소유하고 있는 아이템 번호
        public int Type; // 아이템 종류 번호 - 아이콘, 아이템의 능력치

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

        /*public override bool Equals(object obj)
        {
            if(obj is Item other)
            {
                return Id == other.Id && Type == other.Type;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Type.GetHashCode();
        }*/

    }

    HashSet<Item> items = new HashSet<Item>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        if ( savedItems.Contains(newItem))
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

        //Debug.Log("saveditemLowinfo : " + savedData);

        if(string.IsNullOrEmpty(savedData))
        {
            return new HashSet<Item>();
        }

        string[] itemStrings = savedData.Split(',');
        

        foreach(string itemString in itemStrings)
        {
            Item item = Item.FromString(itemString);
            if(item.Id != 0 || item.Type != 0)
            {
                items.Add(item);
            }
        }

        return items;
    }

    public int GetLastItemNumber()
    {
        HashSet<Item> savedItems = LoadItems();

        if(savedItems.Count == 0)
        {
            Debug.LogWarning("No items are saved.");
            return -1;
        }

        int maxItemNumber = int.MinValue;

        foreach(Item item in savedItems)
        {
            Debug.Log("saved itemID : " + item.Id);

            if(item.Id > maxItemNumber)
            {
                maxItemNumber = item.Id;
            }
        }

        Debug.Log($"Last saved item number: {maxItemNumber}");
        return maxItemNumber;
    }

    public void RemoveItem(int itemId)
    {
        HashSet<Item> savedItems = LoadItems();

        Item itemToRemove = new Item { Id = itemId, Type = 0 };
        bool removed = false;
        foreach(Item item in savedItems)
        {
            if(item.Id == itemId)
            {
                removed = savedItems.Remove(item);
                break;
            }
        }

        if(removed)
        {
            PlayerPrefs.SetString(ItemsKey, string.Join(",", savedItems));
            PlayerPrefs.Save();
            Debug.Log($"Item {itemId} removed successfully.");
        }
        else
        {
            Debug.LogWarning($"Item {itemId} not found.");
        }
    }

    // 골드 추가
    public void AddGold(int amount)
    {
        Gold += amount;
        SaveGold();
    }
    
    // 골드 감소
    public bool SpendGold(int amount)
    {
        if(Gold >= amount)
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
        Debug.Log("Gold : " + Gold);
    }

    // 골드 초기화
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
