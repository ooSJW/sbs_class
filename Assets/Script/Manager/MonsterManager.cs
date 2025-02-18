using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsters;

    public Camera main_camera;
    public RectTransform monsterHP;

    private Monster cur_monster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public int RandomMonsterAttack(CSVLoadManager csv_mng)
    {
        List<RatioInfo> ratioinfo_list = csv_mng.GetRatioInfoList();
        // 1부터 100,000 사이의 난수를 생성
        ulong randomNum = (ulong)UnityEngine.Random.Range(1, 100001);
        //Debug.Log($"[ {info.name} ] 랜덤 값: {randomNum}");

        int grade = 5; // 기본적으로 5등급 (가장 높은 확률)로 설정

        
        foreach( RatioInfo info in ratioinfo_list)
        {
            if (randomNum < info._1)
            {
                grade = 1;
            }
            else if (randomNum < info._2)
            {
                grade = 2;
            }
            else if (randomNum < info._3)
            {
                grade = 3;
            }
            else if (randomNum < info._4)
            {
                grade = 4;
            }

            Debug.Log($"드롭된 등급: {grade}");
        }

        int mon_idx = grade;

        int _2x = UnityEngine.Random.Range(0, 2);
        if(_2x == 1)
        {
            mon_idx *= 2; 
        }

        Debug.Log("MonsterNumber : " + mon_idx);

        monsters[(mon_idx - 1)].SetActive(true);

        Vector3 screenPos = main_camera.WorldToScreenPoint(monsters[(mon_idx - 1)].transform.position);
        screenPos.y += 80.0f;
        monsterHP.position = screenPos;


        return mon_idx;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
