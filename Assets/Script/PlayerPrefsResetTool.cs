#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class PlayerPrefsResetTool : EditorWindow
{
    [MenuItem("Tools/Reset PlayerPrefs")]
    public static void ShowWindow()
    {
        GetWindow<PlayerPrefsResetTool>("Reset PlayerPrefs");
    }

    private void OnGUI()
    {
        GUILayout.Label("PlayerPrefs 초기화", EditorStyles.boldLabel);

        if (GUILayout.Button("PlayerPrefs 삭제"))
        {
            if (EditorUtility.DisplayDialog("확인", "정말로 모든 PlayerPrefs 데이터를 삭제하시겠습니까?", "예", "아니요"))
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
                Debug.Log("모든 PlayerPrefs 데이터가 삭제되었습니다.");
            }
        }
    }
}
#endif
