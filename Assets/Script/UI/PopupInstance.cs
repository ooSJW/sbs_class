using System.Collections.Generic;
using System;
using UnityEngine;

public class PopupInstance : MonoBehaviour
{
    // Lobby �� ������ �ִ� �˾� UI
    public GameObject inventoryPopup;
    public GameObject inventoryListContent;
    public GameObject iteminfoPopup;
    public GameObject DungeonSelectPopup;
    public GameObject questPopup;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.ResetPopupInstance();
    }

    static public void ShowPopup(GameObject showObject, Action SetInfo)
    {
        SetInfo();

        showObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
