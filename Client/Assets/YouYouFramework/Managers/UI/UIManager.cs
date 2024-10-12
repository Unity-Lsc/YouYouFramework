using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// UI 管理器
    /// </summary>
    public class UIManager : ManagerBase
    {
        /// <summary>
        /// 已经打开的UI窗体列表
        /// </summary>
        private LinkedList<UIFormBase> mOpenedUIFormList;

        public UIManager() {
            mOpenedUIFormList = new LinkedList<UIFormBase>();
        }

        /// <summary>
        /// 打开UI窗口
        /// </summary>
        /// <param name="uiFormId">窗口ID</param>
        internal void OpenUIForm(int uiFormId, object userData = null) {

            if (IsUIFormOpened(uiFormId)) return;

            //读表
            var entity = GameEntry.DataTable.DataTableManager.DTSysUIFormDBModel.Get(uiFormId);
            if (entity == null) {
                Debug.LogError(uiFormId + "  对应的UI窗体不存在");
                return;
            }

#if DISABLE_ASSETBUNDLE && UNITY_EDITOR
            UIFormBase formBase = GameEntry.UI.Dequeue(uiFormId);
            if(formBase == null) {

                string localizationPath = string.Empty;
                switch (GameEntry.Localization.CurLanguage) {
                    default:
                    case LocalizationLanguage.Chinese:
                        localizationPath = entity.AssetPath_Chinese;
                        break;
                    case LocalizationLanguage.English:
                        localizationPath = entity.AssetPath_English;
                        break;
                }

                string path = string.Format("Assets/Download/UI/UIPrefab/{0}.prefab", localizationPath);
                Object prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
                GameObject obj = Object.Instantiate(prefab) as GameObject;
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.SetParent(GameEntry.UI.GetUIGroup(entity.UIGroupId).Group);
                rect.localPosition = Vector3.zero;
                rect.localScale = Vector3.one;
                rect.offsetMin = Vector2.zero;
                rect.offsetMax = Vector2.zero;

                formBase = rect.GetComponent<UIFormBase>();
                formBase.Init(uiFormId, entity.UIGroupId, entity.IsDisableUILayer == 1, entity.IsLock == 1, userData);
            } else {
                formBase.gameObject.SetActive(true);
                formBase.Open(userData);
            }
            formBase.IsActive = true;
            mOpenedUIFormList.AddLast(formBase);
#endif
        }

        /// <summary>
        /// 打开UI窗口
        /// </summary>
        /// <param name="uiFormId">窗口ID</param>
        internal void OpenUIForm<T>(int uiFormId, object userData = null) where T : UIFormBase {

            if (IsUIFormOpened(uiFormId)) return;

            //读表
            var entity = GameEntry.DataTable.DataTableManager.DTSysUIFormDBModel.Get(uiFormId);
            if (entity == null) {
                Debug.LogError(uiFormId + "  对应的UI窗体不存在");
                return;
            }
#if DISABLE_ASSETBUNDLE && UNITY_EDITOR
            UIFormBase formBase = GameEntry.UI.Dequeue(uiFormId);
            if(formBase == null) {

                string localizationPath = string.Empty;
                switch (GameEntry.Localization.CurLanguage) {
                    default:
                    case LocalizationLanguage.Chinese:
                        localizationPath = entity.AssetPath_Chinese;
                        break;
                    case LocalizationLanguage.English:
                        localizationPath = entity.AssetPath_English;
                        break;
                }

                string path = string.Format("Assets/Download/UI/UIPrefab/{0}.prefab", localizationPath);
                Object prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
                GameObject obj = Object.Instantiate(prefab) as GameObject;
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.gameObject.AddComponent<T>();
                rect.SetParent(GameEntry.UI.GetUIGroup(entity.UIGroupId).Group);
                rect.localPosition = Vector3.zero;
                rect.localScale = Vector3.one;
                rect.offsetMin = Vector2.zero;
                rect.offsetMax = Vector2.zero;

                formBase = rect.GetComponent<UIFormBase>();
                formBase.Init(uiFormId, entity.UIGroupId, entity.IsDisableUILayer == 1, entity.IsLock == 1, userData);
            } else {
                formBase.gameObject.SetActive(true);
                formBase.Open(userData);
            }
            formBase.IsActive = true;
            mOpenedUIFormList.AddLast(formBase);
#endif
        }

        /// <summary>
        /// 检查UI是否已经打开
        /// </summary>
        /// <param name="uiformId"></param>
        /// <returns></returns>
        internal bool IsUIFormOpened(int uiformId) {
            for(LinkedListNode<UIFormBase> curNode = mOpenedUIFormList.First; curNode != null; curNode = curNode.Next) {
                if (curNode.Value.UIFormId == uiformId) return true;
            }
            return false;
        }

        /// <summary>
        /// 关闭UI窗体(通过窗体关闭)
        /// </summary>
        internal void CloseUIForm(UIFormBase formBase) {
            if (!formBase.IsActive) return;
            Debug.Log("CloseUIForm");
            mOpenedUIFormList.Remove(formBase);
            formBase.ToClose();
        }
        /// <summary>
        /// 关闭UI窗体(通过窗体ID关闭)
        /// </summary>
        internal void CloseUIForm(int uiFormId) {
            for (LinkedListNode<UIFormBase> curNode = mOpenedUIFormList.First; curNode != null; curNode = curNode.Next) {
                if(curNode.Value.UIFormId == uiFormId) {
                    CloseUIForm(curNode.Value);
                    break;
                }
            }
        }

    }
}
