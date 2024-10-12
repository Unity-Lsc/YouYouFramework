using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// UI基类
    /// </summary>
    public class UIFormBase : MonoBehaviour
    {
        /// <summary>
        /// UI窗体编号
        /// </summary>
        public int UIFormId { get; private set; }

        /// <summary>
        /// 分组编号
        /// </summary>
        public byte GroupId { get; private set; }

        /// <summary>
        /// 当前画布
        /// </summary>
        public Canvas CurCanvas { get; private set; }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public float CloseTime { get; private set; }

        /// <summary>
        /// 禁用层级管理
        /// </summary>
        public bool IsDisableUILayer { get; private set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLock { get; private set; }

        /// <summary>
        /// 用户数据
        /// </summary>
        public object UserData { get; private set; }

        /// <summary>
        /// 是否处于激活状态
        /// </summary>
        [HideInInspector]
        public bool IsActive;


        private void Awake() {
            OnAwake();
            CurCanvas = GetComponent<Canvas>();
        }

        private void Start() {
            OnInit(UserData);
            Open(UserData, true);
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="formId">界面ID</param>
        /// <param name="groupId">分组编号</param>
        /// <param name="isDisableUILayer">是否禁用层级管理</param>
        /// <param name="isLock">是否锁定</param>
        /// <param name="userData">参数数据</param>
        internal void Init(int formId, byte groupId, bool isDisableUILayer, bool isLock, object userData) {
            UIFormId = formId;
            GroupId = groupId;
            IsDisableUILayer = isDisableUILayer;
            IsLock = isLock;
            UserData = userData;
        }

        /// <summary>
        /// 打开界面
        /// </summary>
        internal void Open(object userData, bool isFromInit = false) {

            if (!isFromInit) {
                UserData = userData;
            }

            if (!IsDisableUILayer) {
                //进行层级管理 增加层级
                GameEntry.UI.SetSortingOrder(this);
            }

            OnOpen(userData);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        public void Close() {
            GameEntry.UI.CloseUIForm(this);
        }

        public void ToClose() {
            IsActive = false;
            if (!IsDisableUILayer) {
                //进行层级管理 减少层级
                GameEntry.UI.SetSortingOrder(this, false);
            }
            OnClose();
            CloseTime = Time.time;
            GameEntry.UI.Enqueue(this);
        }

        private void OnDestroy() {
            OnBeforeDestory();
        }

        protected virtual void OnAwake() { }

        protected virtual void OnInit(object userData) { }

        protected virtual void OnOpen(object userData) { }

        protected virtual void OnClose() { }

        protected virtual void OnBeforeDestory() { }
    }
}
