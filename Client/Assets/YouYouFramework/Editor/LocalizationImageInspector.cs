using UnityEditor;

namespace YouYou
{
    [CustomEditor(typeof(LocalizationImage))]
    public class LocalizationImageInspector : UnityEditor.UI.ImageEditor
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
