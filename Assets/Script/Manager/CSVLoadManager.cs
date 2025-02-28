using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

public class ScenarioInfo
{
    public int ID;
    public int Chapter;
    public string Character;
    public int CharacterIdx;
    public string Dialogue;
    public int iconIndex;
}

public class CSVLoadManager : MonoBehaviour
{
    private List<List<string>> csvData = new List<List<string>>();

    private List<ItemInfo> itemInfo = new List<ItemInfo>();         // 아이템 정보
    private List<MonsterInfo> monsterInfo = new List<MonsterInfo>();// 몬스터 정보
    private List<RatioInfo> ratioInfo = new List<RatioInfo>();      // 확률 정보
    private List<QuestInfo> questInfo = new List<QuestInfo>();      // 퀘스트 정보
    private List<ShopItemInfo> shopitemInfo = new List<ShopItemInfo>(); // 상점 아이템 정보
    private List<ScenarioInfo> scenarioInfo = new List<ScenarioInfo>(); // 시나리오 정보


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // 아이템 정보 읽어오기
        LoadItemCsv();
        // 몬스터 정보 읽어오기
        LoadMonsterCsv();
        // 확률 정보 읽어오기
        LoadDropRatioCsv();
        // 퀘스트 정보 읽어오기
        LoadQuestCsv();
        // 상점 아이템 정보 읽어오기
        LoadShopItemCsv();
        // 시나리오 정보 읽어오기
        LoadScenarioCsv();
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

    public List<ScenarioInfo> GetScenarioInfoList()
    {
        return scenarioInfo;
    }

    public List<QuestInfo> GetQuestInfoList()
    {
        return questInfo;
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
                    case 1: item.name = field; break; // 이름
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
                    // 필요한 데이터 파싱 추가
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
                    // 필요한 데이터 파싱 추가
                    case 0: shopiteminfo.ID = int.Parse(field); break;
                    case 1: shopiteminfo.name = field; break;
                    case 2: shopiteminfo.itemID = field; break;
                    case 3: shopiteminfo.price = int.Parse(field); break;
                }
                field_num++;
            }
        });
    }

    void LoadScenarioCsv()
    {
        LoadCsv("Scenario", scenarioInfo, (row, info) =>
    {
        ScenarioInfo scenario = info as ScenarioInfo;
        if (scenario == null) return;

        int field_num = 0;
        foreach (string field in row)
        {
            //Debug.Log("field : " + field);
            switch (field_num)
            {
                case 0: scenario.ID = int.Parse(field); break;
                case 1: scenario.Chapter = int.Parse(field); break;
                case 2: scenario.Character = field; break;
                case 3: scenario.CharacterIdx = int.Parse(field); break;
                case 4: scenario.Dialogue = field; break;
                case 5: scenario.iconIndex = int.Parse(field); break;
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
                    // 필요한 데이터 파싱 추가
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
            Debug.Log($"{resourceName} 파일을 로드합니다.");
            string[] rows = csvFile.text.Split('\n');

            foreach (string row in rows)
            {
                // ""로 감싸진 내용에서 ,를 분리 하지 않도록 처리
                List<string> rowData = ParseCsvRow(row);
                csvData.Add(rowData);
            }

            int row_num = 0;
            foreach (List<string> row in csvData)
            {
                if (row_num == 0) // 첫 번째 줄(헤더) 건너뛰기
                {
                    row_num++;
                    continue;
                }

                //Debug.Log($"[{row_num}]");
                T info = new T();

                processRow(row, info); // 제공된 프로세스로 데이터 처리

                dataList.Add(info);
                row_num++;
            }
        }
        else
        {
            Debug.Log($"{resourceName} 파일을 찾을 수 없습니다.");
        }
    }

    // 정규식을 이용한 CSV 행 파싱 함수
    List<string> ParseCsvRow(string row)
    {
        List<string> fields = new List<string>();
        string pattern = "\"(.*?)\"|([^,]+)";
        MatchCollection matches = Regex.Matches(row, pattern);

        foreach (Match match in matches)
        {
            if (match.Groups[1].Success) // 따옴표로 감싸진 값
            {
                fields.Add(match.Groups[1].Value);
            }
            else if (match.Groups[2].Success) // 일반 값
            {
                fields.Add(match.Groups[2].Value);
            }
        }

        return fields;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}