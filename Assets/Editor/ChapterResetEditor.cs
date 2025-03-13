using UnityEngine;
using UnityEditor;

public class ChapterResetEditor : Editor
{
    [MenuItem("Tools/Reset Chapter Info")]
    public static void ResetChapterInfo()
    {
        // PlayerPrefsManager의 인스턴스를 찾습니다.
        PlayerPrefsManager prefsManager = FindObjectOfType<PlayerPrefsManager>();

        if (prefsManager != null)
        {
            // ResetChapterInfo() 함수를 호출합니다.
            prefsManager.ResetChapterInfo();
        }
        else
        {
            Debug.LogError("PlayerPrefsManager를 찾을 수 없습니다.");
        }
    }
}
