using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject attack_obj;

    private float ResetTime;
    private float AttackTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetTime = Time.time;
        //���ݽð��� ĳ���� �������ͽ� ������ �޾ƿͼ� ����
        AttackTime = 3.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayManager.Instance.GetPlayerHP() <= 0) return;
        
        if( ResetTime + AttackTime < Time.time )
        {
            attack_obj.SetActive(true);
            ResetTime = Time.time;
        }
    }
}
