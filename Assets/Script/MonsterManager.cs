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
        // 1���� 100,000 ������ ������ ����
        ulong randomNum = (ulong)UnityEngine.Random.Range(1, 100001);
        //Debug.Log($"[ {info.name} ] ���� ��: {randomNum}");

        List<RatioInfo> ratioinfo_list = csv_mng.GetRatioInfoList();
        foreach( RatioInfo info in ratioinfo_list)
        {
            int grade = 5; // �⺻������ 5��� (���� ���� Ȯ��)�� ����

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

            Debug.Log($"��ӵ� ���: {grade}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
