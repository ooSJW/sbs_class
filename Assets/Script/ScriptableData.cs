using UnityEngine;

public class ScriptableData : MonoBehaviour
{
    public EnemyTable scriptable_data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("ID : " + scriptable_data.enemy_info[0].ID);
        Debug.Log("Name : " + scriptable_data.enemy_info[0].Name);
        Debug.Log("value : " + scriptable_data.enemy_info[0].value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
