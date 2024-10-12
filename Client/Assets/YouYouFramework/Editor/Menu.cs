using UnityEngine;
using UnityEditor;

public class Menu
{
    [MenuItem("Tools/Settings")]
    public static void Settings() {

        SettingsWindow window = EditorWindow.GetWindow<SettingsWindow>();
        window.titleContent = new GUIContent("全局设置");
        window.Show();

    }

}
