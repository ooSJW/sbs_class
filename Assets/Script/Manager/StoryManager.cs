using UnityEngine;

public enum ActType
{
    Scenario = 0,
    ItemUse = 1001,
    DungeonMove = 1002,
    NewFriend = 1003,
}

public class StoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DoNextStory()
    {
        // 스토리 정보에 대한 시나리오 팝업 오픈
        PopupInstance.Instance.ScenarioPopupOpen(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
