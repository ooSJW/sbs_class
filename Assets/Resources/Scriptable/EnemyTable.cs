using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EnemyInfo
{
    public int ID;
    public string Name;
    public float value;
}

[CreateAssetMenu(fileName = "EnemyTable", menuName = "Scriptable Objects/EnemyTable")]
public class EnemyTable : ScriptableObject
{
    public List<EnemyInfo> enemy_info = new List<EnemyInfo>();
}
