using UnityEngine;
using UnityEngine.UI;

public class TransText : MonoBehaviour
{
    public string text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string find_language = GameManager.Instance.prefsManager.LoadLanguage("ko");
        //string find_language = GameManager.Instance.localMng.GetLanguageCode();
        GameManager.Instance.localMng.SetLanguage(find_language);
        string _text = GameManager.Instance.localMng.GetLocalizedText(text);
        GetComponent<Text>().text = _text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
