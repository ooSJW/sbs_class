using UnityEngine;

public enum UIElement
{
    NONE,
    TOPUI,
    INVENTORY,
    SHOP,
    OPTION,
}

public class RefreshElement : MonoBehaviour
{
    protected UIElement element = UIElement.NONE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 생성될때 GameManager의 UI목록 Dictionary에 등록
        // 상속 처리 시에 어떤 종류의 UI인지 셋팅 필요
    }

    virtual protected void SetElementToManager()
    {
        GameManager.Instance.SetElementToManager(element, this);
    }

    public void CloseBtn()
    {
        gameObject.SetActive(false);
    }

    virtual public void RefreshUI()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
