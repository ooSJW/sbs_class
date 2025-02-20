using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public int item_number;
    public string name;
    public int ability;
    public int sellprice;
}

public class MonsterInfo
{
    public int id;
    public string name;
    public int attack;
    public int defence;
    public int HP;
    public int dropItem;
    public int addGold;
}

public class RatioInfo
{
    public int id;
    public string name;
    public ulong _1;
    public ulong _2;
    public ulong _3;
    public ulong _4;
    public ulong _5;
}

public class QuestInfo
{

}

public class ShopItemInfo
{
    public int ID;
    public string name;
    public string itemID;
    public int price;
}

public class CSVLoadManager : MonoBehaviour
{
    private List<List<string>> csvData = new List<List<string>>();

    private List<ItemInfo> itemInfo = new List<ItemInfo>();         // ������ ����
    private List<MonsterInfo> monsterInfo = new List<MonsterInfo>();// ���� ����
    private List<RatioInfo> ratioInfo = new List<RatioInfo>();      // Ȯ�� ����
    private List<QuestInfo> questInfo = new List<QuestInfo>();      // ����Ʈ ����
    private List<ShopItemInfo> shopitemInfo = new List<ShopItemInfo>(); // �� ������ ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // ������ ���� �о����
        LoadItemCsv();
        // ���� ���� �о����
        LoadMonsterCsv();
        // Ȯ�� ���� �о����
        LoadDropRatioCsv();
        // ����Ʈ ���� �о����
        LoadQuestCsv();
        // �� ������ ���� �о����
        LoadShopItemCsv();
    }

    public List<ItemInfo> GetItemList()
    {
        return itemInfo;
    }

    public ItemInfo FindItemInfo(int type)
    {
        foreach (ItemInfo info in itemInfo)
            if (info.item_number == type) return info;
        return null;
    }

    public ShopItemInfo FindShopItemInfo(int type)
    {
        foreach (ShopItemInfo info in shopitemInfo)
            if (int.Parse(info.itemID) == type) return info;
        return null;
    }

    public List<MonsterInfo> GetMonsterList()
    {
        return monsterInfo;
    }

    public List<RatioInfo> GetRatioInfoList()
    {
        return ratioInfo;
    }

    public List<ShopItemInfo> GetShopitemInfoList()
    {
        return shopitemInfo;
    }

    void LoadItemCsv()
    {
        LoadCsv("Item", itemInfo, (row, info) =>
        {
            ItemInfo item = info as ItemInfo;
            if (item == null) return;

            int field_num = 0;
            foreach (string field in row)
            {
                //Debug.Log("field : " + field);
                switch (field_num)
                {
                    case 0: item.item_number = int.Parse(field); break;
                    case 1: item.name = field; break; // �̸�
                    case 2: item.ability = int.Parse(field); break;
                    case 3: item.sellprice = int.Parse(field); break;
                }
                field_num++;
            }
        });
    }

    void LoadMonsterCsv()
    {
        LoadCsv("Monster", monsterInfo, (row, info) =>
        {
            MonsterInfo monster = info as MonsterInfo;
            if (monster == null) return;

            int field_num = 0;
            foreach (string field in row)
            {
                //Debug.Log("field : " + field);
                switch (field_num)
                {
                    // �ʿ��� ������ �Ľ� �߰�
                    case 0: monster.id = int.Parse(field); break;
                    case 1: monster.name = field; break;
                    case 2: monster.attack = int.Parse(field); break;
                    case 3: monster.defence = int.Parse(field); break;
                    case 4: monster.HP = int.Parse(field); break;
                    case 5: monster.dropItem = int.Parse(field); break;
                    case 6: monster.addGold = int.Parse(field); break;
                }
                field_num++;
            }
        });
    }

    void LoadShopItemCsv()
    {
        LoadCsv("Shop", shopitemInfo, (row, info) =>
        {
            ShopItemInfo shopiteminfo = info as ShopItemInfo;
            if (shopiteminfo == null) return;

            int field_num = 0;
            foreach (string field in row)
            {
                Debug.Log("field : " + field);
                switch (field_num)
                {
                    // �ʿ��� ������ �Ľ� �߰�
                    case 0: shopiteminfo.ID = int.Parse(field); break;
                    case 1: shopiteminfo.name = field; break;
                    case 2: shopiteminfo.itemID = field; break;
                    case 3: shopiteminfo.price = int.Parse(field); break;

                }
                field_num++;
            }

        });
    }

    void LoadDropRatioCsv()
    {
        LoadCsv("DropRatio", ratioInfo, (row, info) =>
        {
            RatioInfo ratioinfo = info as RatioInfo;
            if (ratioinfo == null) return;

            int field_num = 0;
            foreach (string field in row)
            {
                //Debug.Log("field : " + field);
                switch (field_num)
                {
                    // �ʿ��� ������ �Ľ� �߰�
                    case 0: ratioinfo.id = int.Parse(field); break;
                    case 1: ratioinfo.name = field; break;
                    case 2: ratioinfo._1 = ulong.Parse(field); break;
                    case 3: ratioinfo._2 = ulong.Parse(field); break;
                    case 4: ratioinfo._3 = ulong.Parse(field); break;
                    case 5: ratioinfo._4 = ulong.Parse(field); break;
                    case 6: ratioinfo._5 = ulong.Parse(field); break;
                }
                field_num++;
            }
        });
    }

    void LoadQuestCsv()
    {
        csvData.Clear();
    }

    void LoadCsv<T>(string resourceName, List<T> dataList, Action<List<string>, T> processRow) where T : new()
    {
        csvData.Clear();

        TextAsset csvFile = Resources.Load<TextAsset>(resourceName);
        if (csvFile != null)
        {
            Debug.Log($"{resourceName} ������ �����մϴ�.");
            string[] rows = csvFile.text.Split('\n');

            foreach (string row in rows)
            {
                string[] fields = row.Split(',');
                List<string> rowData = new List<string>(fields);
                csvData.Add(rowData);
            }

            int row_num = 0;
            foreach (List<string> row in csvData)
            {
                if (row_num == 0) // ù ��° ��(���) ��ŵ
                {
                    row_num++;
                    continue;
                }

                //Debug.Log($"[{row_num}]");
                T info = new T();

                processRow(row, info); // ���޵� ��������Ʈ ����

                dataList.Add(info);
                row_num++;
            }
        }
        else
        {
            Debug.Log($"{resourceName} ������ �������� �ʽ��ϴ�.");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
