using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void RandomMonsterAttack(CSVLoadManager csv_mng)
    {
        // 1부터 100,000 사이의 난수를 생성
        ulong randomNum = (ulong)UnityEngine.Random.Range(1, 100001);
        //Debug.Log($"[ {info.name} ] 랜덤 값: {randomNum}");

        List<RatioInfo> ratioinfo_list = csv_mng.GetRatioInfoList();
        foreach( RatioInfo info in ratioinfo_list)
        {
            int grade = 5; // 기본적으로 5등급 (가장 높은 확률)로 설정

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
