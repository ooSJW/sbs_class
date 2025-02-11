using UnityEngine;

public class Monster : MonoBehaviour
{
    float attack_time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attack_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(attack_time + 3.0f < Time.time)
        {
            GetComponent<Animator>().Play("Attack");
            attack_time = Time.time;
        }
    }
}
