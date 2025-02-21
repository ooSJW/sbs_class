using UnityEngine;
using UnityEngine.UI;

public class TransText : MonoBehaviour
{
    public string text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Text마다 해당 스크립트를 가지고있고, 에디터에서 작성한 키값으로 일치하는 항목을 탐색 후 text를 변경해줌.
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
