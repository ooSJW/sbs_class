
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    //PlayerHP
    int playerHP; //GameManager를 통해 초기 값 설정 필요
    public Slider playerHP_bar;
    //MonsterHP
    int monsterHP; //GameManager를 통해 초기 값 설정 필요
    public Slider monsterHP_bar;

    // 보물상자 , 번호
    public GameObject treatureObject;
    private int treatureItemNum;

    private GameManager game_mng;
    public MonsterManager monster_mng;
    private int curMonsterID = 1;

    public static PlayManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    int playerHP_MAX = 15;
    int monsterHP_MAX = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game_mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        curMonsterID = monster_mng.RandomMonsterAttack(game_mng.csvloadManager);

        playerHP = 15;
        monsterHP = 10;

        AddExp();
        StartCoroutine(ItemDropCo());
        //DropItem();
        AddItem();
        DoQuest();
    }

    public int GetPlayerHP()
    {
        return playerHP;
    }

    public int GetMonsterHP()
    {
        return monsterHP;
    }

    public void SetPlayerHP(int Damage)
    {
        playerHP -= Damage;
        float val = 1.0f;
        if (playerHP <= 0)
        {
            val = 0;
            playerHP = 0;
        }
        else
            val = (float)playerHP / (float)playerHP_MAX;

        playerHP_bar.value = val;
        playerHP_bar.GetComponent<SliderNum>().SetNum(playerHP, playerHP_MAX);
    }

    public bool SetMonsterHP(int Damage)
    {
        bool deadMonster = false;
        monsterHP -= Damage;
        float val = 1.0f;
        if (monsterHP <= 0)
        {
            val = 0;
            monsterHP = 0;
            DropItem();
            deadMonster = true;
        }
        else
            val = (float)monsterHP / (float)monsterHP_MAX;

        monsterHP_bar.value = val;
        monsterHP_bar.GetComponent<SliderNum>().SetNum(monsterHP, monsterHP_MAX);

        return deadMonster;
    }

    public int CurrentDropItemNumber()
    {
        return treatureItemNum;
    }

    public void AddExp()
    {

    }

    IEnumerator ItemDropCo()
    {
        yield return new WaitForSeconds(5f);

        //DropItem();
    }

    public void DropItem()
    {
        List<MonsterInfo> monster_list = game_mng.csvloadManager.GetMonsterList();
        MonsterInfo dead_monster = null;
        foreach(MonsterInfo monster_info in monster_list)
        {
            // 랜덤으로 선택된 몬스터 정보를 기반으로 아이템 드랍
            if (monster_info.id == curMonsterID)
            {
                dead_monster = monster_info;
                break;
            }
        }

        if(dead_monster != null)
        {
            //CreateTreature - 아이템 번호
            treatureObject.SetActive(true);
            treatureItemNum = dead_monster.dropItem;

            Debug.Log("Drop Item : " + treatureItemNum);
        }
    }

    public void AddItem()
    {
        // PlayerPrefs 에 아이템 획득 기록
    }

    public void DoQuest()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 시간에 따른 hp 감소
    }
}
