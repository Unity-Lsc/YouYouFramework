using UnityEditor;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 对象池在监视器的面板
    /// </summary>
    [CustomEditor(typeof(PoolComponent), true)]
    public class PoolComponentInspector : Editor
    {
        /// <summary>
        /// 释放间隔 的属性
        /// </summary>
        private SerializedProperty mClearInterval = null;

        /// <summary>
        /// 游戏物体对象池分组 的属性
        /// </summary>
        private SerializedProperty mGameObjectPoolEntityGroup = null;

        public override void OnInspectorGUI() {
            //base.OnInspectorGUI();//显示父节点(PoolComponent)中的属性
            //更新序列化对象的表示形式
            serializedObject.Update();

            var component = base.target as PoolComponent;

            //绘制滑动条
            int clearInterval = (int)EditorGUILayout.Slider("清空类对象池的时间间隔", mClearInterval.intValue, 10, 1800);
            if (clearInterval != mClearInterval.intValue) {
                component.ClearInterval = clearInterval;
            } else {
                mClearInterval.intValue = clearInterval;
            }
            #region 类对象池
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("类名");
            GUILayout.Label("池中数量", GUILayout.Width(55));
            GUILayout.Label("常驻数量", GUILayout.Width(55));
            GUILayout.EndHorizontal();

            if (component != null && component.PoolManager != null) {
                foreach (var item in component.PoolManager.ClassObjectPool.InspectorDict) {
                    GUILayout.BeginHorizontal("box");

                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(55));

                    //显示类对象池常驻数量
                    int key = item.Key.GetHashCode();
                    byte residentCount = 0;
                    component.PoolManager.ClassObjectPool.ClassObjectResidentDict.TryGetValue(key, out residentCount);
                    GUILayout.Label(residentCount.ToString(), GUILayout.Width(55));

                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            #endregion

            #region 变量对象池
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("变量");
            GUILayout.Label("数量", GUILayout.Width(55));
            GUILayout.EndHorizontal();

            if (component != null) {
                foreach (var item in component.VarObjectInspectorDict) {
                    GUILayout.BeginHorizontal("box");

                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(55));

                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            #endregion

            GUILayout.Space(10);
            EditorGUILayout.PropertyField(mGameObjectPoolEntityGroup, true);
            serializedObject.ApplyModifiedProperties();
            //Unity面板重绘
            Repaint();

        }

        private void OnEnable() {
            //建立属性关系
            mClearInterval = serializedObject.FindProperty("ClearInterval");
            mGameObjectPoolEntityGroup = serializedObject.FindProperty("mGameObjectPoolEntityGroup");

            //应用 属性信息的修改
            serializedObject.ApplyModifiedProperties();
        }

    }
}
