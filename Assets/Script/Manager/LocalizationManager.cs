using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, string>> localizedText = new 
        Dictionary<string, Dictionary<string, string>>();

    private string currentLanguage = "ko";
    private void Awake()
    {
        LoadLocalizationData("Local_Text");
    }
    
    public string GetLanguageCode()
    {
        SystemLanguage systemLanguage = Application.systemLanguage;

        switch (systemLanguage)
        {
            case SystemLanguage.Korean: return "ko";
            case SystemLanguage.English: return "en";
            case SystemLanguage.Japanese: return "ja";
            case SystemLanguage.ChineseSimplified: return "zh-CH";
            case SystemLanguage.ChineseTraditional: return "zh-TW";
            case SystemLanguage.French: return "fr";
            case SystemLanguage.German: return "de";
            case SystemLanguage.Spanish: return "es";
            case SystemLanguage.Russian: return "ru";
            default: return "en";
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void LoadLocalizationData(string fileName)
    {
        TextAsset file = Resources.Load<TextAsset>(fileName);
        if(file == null)
        {
            Debug.LogError("Localization file not found!");
            return;
        }

        string[] lines = file.text.Split('\n');
        string[] headers = lines[0].Split(',');

        for(int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(',');

            if (row.Length < headers.Length)
                continue; // 빈 줄 무시

            // "en" 열을 키로 사용
            string key = row[3].Trim(); // 공백 문자 제거
            Dictionary<string, string> translations = new Dictionary<string, string>();

            // 언어별 번역 추가(ko, en, jp)
            for(int j = 2; j < headers.Length; j++) // ID와 Name 건너띄고 ko부터 시작
            {
                translations[headers[j].Trim()] = row[j].Trim();
            }

            localizedText[key] = translations;
        }
    }

    public string GetLocalizedText(string key)
    {
        if(localizedText.ContainsKey(key) && localizedText[key].ContainsKey(currentLanguage))
        {
            return localizedText[key][currentLanguage];
        }
        return key; // 키가 없으면 키 자체를 반환
    }

    public void SetLanguage(string language)
    {
        if(localizedText.Count > 0 && localizedText.ContainsKey("Store") &&
            localizedText["Store"].ContainsKey(language))
        {
            currentLanguage = language;
        }
        else
        {
            Debug.LogWarning("Language not supported: " + language);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
