
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    //PlayerHP
    int playerHP;
    Slider playerHP_bar;
    //MonsterHP
    int monsterHP;
    Slider monsterHP_bar;

    // 보물상자 , 번호
    public GameObject treatureObject;
    private int treatureItemNum;

    private GameManager game_mng;
    public MonsterManager monster_mng;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game_mng = GameObject.Find("GameManager").GetComponent<GameManager>();
        monster_mng.RandomMonsterAttack(game_mng.csvloadManager);

        AddExp();
        StartCoroutine(ItemDropCo());
        //DropItem();
        AddItem();
        DoQuest();
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

        DropItem();
    }

    public void DropItem()
    {
        List<MonsterInfo> monster_list = game_mng.csvloadManager.GetMonsterList();
        MonsterInfo dead_monster = null;
        foreach(MonsterInfo monster_info in monster_list)
        {
            if (monster_info.id == 1)
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
