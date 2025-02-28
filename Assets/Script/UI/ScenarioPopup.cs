using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScenarioPopup : MonoBehaviour
{
    private int targetChapter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<ScenarioInfo> list = GameManager.Instance.csvloadManager.GetScenarioInfoList();

        targetChapter = 1;

        // 해당 Chapter에서 가장 작은 ID를 가진 ScenarioInfo 찾기
        ScenarioInfo scenario = list
            .Where(s => s.Chapter == targetChapter)  // Chapter가 같은 것만 필터링
            .OrderBy(s => s.ID)                      // ID 기준으로 정렬
            .FirstOrDefault();                        // 가장 첫 번째 요소 선택

        // 찾은 경우 해당 Dialogue 사용
        string talk = scenario != null ? scenario.Dialogue : "";
        
        GetComponent<Dialog>().StartReadScenario(talk);
    }

    public void SetChapterIdx()
    {
        int chapter;
        bool progress;
        GameManager.Instance.prefsManager.LoadChapterInfo(out chapter, out progress);
        targetChapter = chapter;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
