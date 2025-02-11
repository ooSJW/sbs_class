using UnityEngine;

public class FireMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    bool dirLeft = true;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (dirLeft == true)
        {
            pos.x -= 5 * Time.deltaTime;
            if (pos.x < -16) dirLeft = false;
        }
        else if(dirLeft == false)
        {
            pos.x += 5 * Time.deltaTime;
            if (pos.x > -10) dirLeft = true;
        }

        transform.position = pos;
    }
}
