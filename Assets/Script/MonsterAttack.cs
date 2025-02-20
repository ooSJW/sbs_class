using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject attack_obj;

    private float ResetTime;
    private float AttackTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetTime = Time.time;
        //공격시간을 몬스터 CSV에서 값을 가져온다.
        AttackTime = 2.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayManager.Instance.GetMonsterHP() <= 0) return;

        if ( ResetTime + AttackTime < Time.time )
        {
            attack_obj.SetActive(true);
            ResetTime = Time.time;
        }
    }
}
