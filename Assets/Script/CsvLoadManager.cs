using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
[System.Serializable]
public class BaseInformation
{
    public string index;
}
[System.Serializable]
public class ItemInfo : BaseInformation
{
    public string itemName;
    public int abillty;
}
public class QuestInfo : BaseInformation
{

}
public partial class CsvLoadManager : MonoBehaviour // Data Field
{
    // Item information
    private List<List<string>> csvItemData = new List<List<string>>();
    private List<ItemInfo> itemInfoList = new List<ItemInfo>();

    // Quest information
    private List<List<string>> csvQuestData = new List<List<string>>();
    private List<QuestInfo> questInfoList = new List<QuestInfo>();

    // TEST
    private Dictionary<string, ItemInfo> itemDict = new Dictionary<string, ItemInfo>();
}
public partial class CsvLoadManager : MonoBehaviour // Property
{
    public void LoadCsv<T>(Dictionary<string, T> dataDict, string path) where T : BaseInformation, new()
    {
        dataDict.Clear();
        TextAsset csvFile = Resources.Load<TextAsset>(path);
        if (csvFile != null)
        {
            string[] csvFileArray = csvFile.text.Split('\n');
            for (int i = 1; i < csvFileArray.Length; i++)
            {
                string[] csvValue = csvFileArray[i].Split(",");
                dataDict.Add(csvValue[0], ParseData<T>(csvValue));
            }
        }
        else
            Debug.Log($"File is Null : [{path}] [{typeof(T)}]");
    }

    public T ParseData<T>(string[] values) where T : BaseInformation, new()
    {
        T data = new T();
        FieldInfo[] fieldInfoArray = typeof(T).GetFields();
        if (values.Length == fieldInfoArray.Length)
        {
            // values[0] : 모든 데이터 파일의 첫 번째 값은 키 값으로 사용할 index로 선언 
            data.index = values[0];
            for (int i = 0; i < values.Length - 1; i++)
            {
                FieldInfo fieldInfo = fieldInfoArray[i];
                string value = values[i + 1];

                if (fieldInfo.FieldType == typeof(int))
                    fieldInfo.SetValue(data, int.Parse(value));
                else if (fieldInfo.FieldType == typeof(string))
                    fieldInfo.SetValue(data, value);
                else if (fieldInfo.FieldType == typeof(float))
                    fieldInfo.SetValue(data, float.Parse(value));
            }
        }
        else
        {
            print($"ParsingError : {typeof(T)}");
            return null;
        }

        return data;
    }
    public void LoadItemCsv()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("ItemData");
        if (csvFile != null)
        {
            Debug.Log("파일 존재");
            string[] csvFileArray = csvFile.text.Split('\n');
            foreach (string csv in csvFileArray)
            {
                List<string> data = csv.Split(',').ToList();
                csvItemData.Add(data);
            }

            int rowNumber = 0;

            foreach (List<string> strings in csvItemData)
            {
                Debug.Log("[" + rowNumber + "]");
                if (rowNumber == 0)
                {
                    rowNumber++;
                    continue;
                }
                ItemInfo itemInfo = new ItemInfo();
                int fieldNumber = 0;
                foreach (string field in strings)
                {
                    Debug.Log("field : " + field);
                    switch (fieldNumber)
                    {
                        case 0:
                            itemInfo.index = field;
                            break;
                        case 1:
                            itemInfo.itemName = field;
                            break;
                        case 2:
                            itemInfo.abillty = int.Parse(field);
                            break;
                    }
                    fieldNumber++;
                }
                itemInfoList.Add(itemInfo);
                rowNumber++;
            }

        }
        else
            Debug.Log("File is Null");
    }
    public void LoadQuestCsv()
    {

    }

    public List<ItemInfo> GetItemInfo()
    {
        return itemInfoList;
    }
}
public partial class CsvLoadManager : MonoBehaviour // main
{
    private void Awake()
    {
        // TODO : 아이템, 퀘스트 정보 읽어오기
        LoadItemCsv();
        LoadQuestCsv();
        LoadCsv<ItemInfo>(itemDict, "ItemData");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}