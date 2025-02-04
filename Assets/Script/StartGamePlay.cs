using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGamePlay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void StartPlay()
    {
        // TODO 스테이저 선택 팝업 처리 예정

        SceneManager.LoadScene("InGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
