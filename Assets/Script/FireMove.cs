using UnityEngine;

public class FireMove : MonoBehaviour
{
    public bool IsMonster = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    bool dirLeft = true;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (IsMonster)
        {
            pos.x -= 5 * Time.deltaTime;
            if (pos.x < -17)
            {
                pos.x = -11;
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            pos.x += 5 * Time.deltaTime;
            if (pos.x > -11)
            {
                pos.x = -17;
                this.gameObject.SetActive(false);
            }
        }

        transform.position = pos;
    }
}
