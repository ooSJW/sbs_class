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
        // TODO �������� ���� �˾� ó�� ����

        SceneManager.LoadScene("InGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
