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
        // 알파 값을 0.2 ~ 1 사이에서 무한 반복 (깜빡임)
        canvasGroup.DOFade(0.2f, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
