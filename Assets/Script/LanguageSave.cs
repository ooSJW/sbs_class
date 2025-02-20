using UnityEngine;

public class LanguageSave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetLanguageSave(string language)
    {
        GameManager.Instance.prefsManager.SaveLanguage(language);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
