using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dlgText;
    private Coroutine typingCoroutine;
    string scenario = "";

    void Start()
    {
        
    }

    public void StartReadScenario(string talk)
    {
        scenario = talk;
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeDialogue(scenario));
    }

    // 코루틴으로 실행할 수 있는 메서드 추가
    public IEnumerator StartReadScenarioCoroutine(string talk)
    {
        scenario = talk;
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeDialogue(scenario)); // TypeDialogue 완료를 기다림
        yield return typingCoroutine;
    }

    public void StopTyping()
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            dlgText.text = scenario;
        }
    }

    IEnumerator TypeDialogue(string scenario)
    {
        float typingSpeed = 0.05f;

        dlgText.text = "";
        foreach (char word in scenario.ToCharArray())
        {
            dlgText.text = dlgText.text + word;
            yield return new WaitForSeconds(typingSpeed);
        }
        typingCoroutine = null;
        yield break;
    }

    void Update()
    {
        
    }
}