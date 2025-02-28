using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dlgText;

    string scenario = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void StartReadScenario(string talk)
    {
        scenario = talk;
        StartCoroutine(TypeDialogue(scenario));
    }

    //코루틴 함수 리턴값 IEnumerator
    IEnumerator TypeDialogue(string scenario)
    {
        float typingSpeed = 0.05f;

        dlgText.text = "";
        foreach( char word in scenario.ToCharArray() )
        {
            dlgText.text = dlgText.text + word;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield break;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
