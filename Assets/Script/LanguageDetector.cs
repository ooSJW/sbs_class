using UnityEngine;
using UnityEngine.UI;

public class LanguageDetector : MonoBehaviour
{
    public Text laguageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SystemLanguage systemLanguage = Application.systemLanguage;
        string language = GetLanguageCode(systemLanguage);
        laguageText.text = "Detected Language: " + language;
    }

    string GetLanguageCode(SystemLanguage systemLanguage)
    {
        switch(systemLanguage)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
