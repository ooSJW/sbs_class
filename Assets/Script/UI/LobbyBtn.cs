using UnityEngine;

public class LobbyBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void InventoryPopupOpen()
    {
        GameManager.Instance.InventoryPopupOpen();
    }

    public void DungeonSelectPopupOpen()
    {
        GameManager.Instance.DungeonSelectPopupOpen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
