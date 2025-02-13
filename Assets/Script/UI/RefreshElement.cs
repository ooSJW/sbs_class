using UnityEngine;

public enum UIElement
{
    NONE,
    INVENTORY,
    TOPUI,
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

    virtual public void RefreshUI()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
