using UnityEditor;

namespace YouYou
{
    [CustomEditor(typeof(LocalizationText))]
    public class LocalizationTextInspector : UnityEditor.UI.TextEditor
    {

        private SerializedProperty mLocalizationKey;

        protected override void OnEnable() {
            base.OnEnable();
            mLocalizationKey = serializedObject.FindProperty("mLocalizationKey");
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.PropertyField(mLocalizationKey);
            serializedObject.ApplyModifiedProperties();
        }


    }
}
