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
        GUILayout.Label("PlayerPrefs 관리", EditorStyles.boldLabel);

        if (GUILayout.Button("모든 PlayerPrefs 삭제"))
        {
            if (EditorUtility.DisplayDialog("경고", "모든 PlayerPrefs 데이터를 삭제하시겠습니까?", "예", "아니오"))
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
                Debug.Log("모든 PlayerPrefs 데이터가 삭제되었습니다.");
            }
        }
    }
}
