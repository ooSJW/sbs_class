using UnityEngine;
using DG.Tweening;

public class BtnAlpha : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartBlink();
    }

    void StartBlink()
    {
        // ���� ���� 0.2 ~ 1 ���̿��� ���� �ݺ� (������)
        canvasGroup.DOFade(0.2f, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
