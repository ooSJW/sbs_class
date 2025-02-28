using UnityEngine;

public enum UIElement
{
    NONE,
    TOPUI,
    INVENTORY,
    SHOP,
    OPTION,
    MERCENARY,
}

public class RefreshElement : MonoBehaviour
{
    protected UIElement element = UIElement.NONE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �����ɶ� GameManager�� UI��� Dictionary�� ���
        // ��� ó�� �ÿ� � ������ UI���� ���� �ʿ�
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
