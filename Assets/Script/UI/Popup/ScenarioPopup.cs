using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ScenarioPopup : MonoBehaviour
{
    private int targetStory = 0;

    private int cur_id = 0, end_id = 0;

    public Image portraitImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void SetChapterIdx()
    {
        int story;
        StoryProgress progress;
        GameManager.Instance.prefsManager.LoadChapterInfo(out story, out progress);
        targetStory = story;
        
    }

    void OnEnable()
    {
        List<ScenarioInfo> list = GameManager.Instance.csvloadManager.GetScenarioInfoList();

        // 해당 Chapter에서 가장 작은 ID를 가진 ScenarioInfo 찾기
        ScenarioInfo scenario_s = list
            .Where(s => s.Story == targetStory)  // Chapter가 같은 것만 필터링
            .OrderBy(s => s.ID)                      // ID 기준으로 정렬
            .FirstOrDefault();                        // 가장 첫 번째 요소 선택

        cur_id = scenario_s.ID;
        //Debug.Log("시작 대사 번호 : " + cur_id);

        // 찾은 경우 해당 Dialogue 사용
        string talk = scenario_s != null ? scenario_s.Dialogue : "";

        // 초상화 이미지 셋팅
        Sprite sprite = GameManager.Instance.GetPortraitImage((scenario_s.iconIndex-1));

        portraitImage.sprite = sprite;

        GetComponent<Dialog>().StartReadScenario(talk);

        // 현재 챕터의 가장 큰 ID 찾기
        ScenarioInfo scenario_e = list
            .Where(s => s.Story == targetStory)  // Chapter가 같은 것만 필터링
            .OrderBy(s => s.ID)                      // ID 기준으로 정렬
            .LastOrDefault();

        end_id = scenario_e.ID;

        //Debug.Log("마지막 대사 번호 : " + end_id);

        
    }

    private Coroutine currentCoroutine;

    public void NextBtnClick()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            GetComponent<Dialog>().StopTyping();
        }

        cur_id++;

        // 코루틴이 끝난 후에 end_id 체크
        if (cur_id == (end_id+1))
        {
            // 현재 챕터를 진행 중으로 변경
            // 현재 보여지고 있는 ID 번호와 비교해서 같다면 창을 닫는다.
            gameObject.SetActive(false);
            

            // 현재 챕터의 마지막 시나리오 찾기
            ScenarioInfo lastScenario = GameManager.Instance.csvloadManager.GetScenarioInfoList()
            .FindLast(x => x.Story == targetStory);

            switch(lastScenario.eventType)
            {
            case ActType.Scenario: GameManager.Instance.prefsManager.SaveChapterInfo(targetStory+1, StoryProgress.Completed); break;
            case ActType.ItemUse: PopupInstance.Instance.ItemUsePopupOpen(); break;
            case ActType.DungeonMove: PopupInstance.Instance.DungeonSelectPopupOpen(); break;
            case ActType.NewFriend: PopupInstance.Instance.NewFriendPopupOpen(); break;
            }

            return;
        }

        List<ScenarioInfo> list = GameManager.Instance.csvloadManager.GetScenarioInfoList();

        ScenarioInfo item = list.Find(x => x.ID == cur_id);
        if (item != null)
        {
            Sprite sprite = GameManager.Instance.GetPortraitImage((item.iconIndex-1));

            portraitImage.sprite = sprite;

            string talk = item != null ? item.Dialogue : "";
            // StartReadScenario를 코루틴으로 실행하고 완료를 기다림
            currentCoroutine = StartCoroutine(ReadScenarioAndCheckEnd(talk));
        }
    }

    private IEnumerator ReadScenarioAndCheckEnd(string talk)
    {
        // Dialog 컴포넌트에서 StartReadScenario 호출
        Dialog dialog = GetComponent<Dialog>();
        dialog.dlgText.text = "";
        yield return StartCoroutine(dialog.StartReadScenarioCoroutine(talk)); // 코루틴 완료를 기다림

        
    }



    // Update is called once per frame
    void Update()
    {

    }
}
