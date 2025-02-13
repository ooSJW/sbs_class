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
        GUILayout.Label("PlayerPrefs ����", EditorStyles.boldLabel);

        if (GUILayout.Button("��� PlayerPrefs ����"))
        {
            if (EditorUtility.DisplayDialog("���", "��� PlayerPrefs �����͸� �����Ͻðڽ��ϱ�?", "��", "�ƴϿ�"))
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
                Debug.Log("��� PlayerPrefs �����Ͱ� �����Ǿ����ϴ�.");
            }
        }
    }
}
