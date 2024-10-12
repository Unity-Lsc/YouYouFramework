using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YouYou
{
    //UI适配的三种情况(横屏)
    //1.UILoading适配(有背景图),进行动态计算Match的值
    //2.全屏类窗口,设置Match的值为1
    //3.普通类窗口,大于等于标准比值,Match的值为1,小于标准比值Match的值为0


    /// <summary>
    /// UI组件
    /// </summary>
    public class UIComponent : YouYouBaseComponent, IUpdateComponent
    {
        /// <summary>
        /// 标准分辨率的宽度
        /// </summary>
        private readonly int mStandardWidth = 1280;
        /// <summary>
        /// 标准分辨率的高度
        /// </summary>
        private readonly int mStandardHeight = 720;

        /// <summary>
        /// 根画布
        /// </summary>
        private Canvas mUIRootCanvas;
        /// <summary>
        /// 根画布的缩放
        /// </summary>
        private CanvasScaler mUIRootCanvasScaler;
        

        [Header("UI摄像机")]
        [HideInInspector]
        public Camera UICamera;

        /// <summary>
        /// 标准的屏幕宽高比值
        /// </summary>
        private float mStandardScreenRatio = 0;
        /// <summary>
        /// 实际的屏幕宽高比值
        /// </summary>
        private float mCurScreenRatio = 0;

        /// <summary>
        /// UI分组的集合
        /// </summary>
        [SerializeField]
        private UIGroup[] UIGroups;

        private Dictionary<byte, UIGroup> mUIGroupDict;

        private UIManager mUIManager;
        private UILayer mUILayer;
        private UIPool mUIPool;

        /// <summary>
        /// 释放间隔(单位秒)
        /// </summary>
        private readonly float mClearInterval = 120f;
        /// <summary>
        /// 下次的运行时间
        /// </summary>
        private float mNextRunTime = 0f;
        /// <summary>
        /// UI回池后的过期时间
        /// </summary>
        public readonly float mUIExpireTime = 120f;
        /// <summary>
        /// UI对象池中 最大的数量
        /// </summary>
        public readonly ushort UIPoolMaxCount = 5;

        protected override void OnAwake() {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            //查找组件
            var root = transform.Find("UIRoot");
            mUIRootCanvas = root.GetComponent<Canvas>();
            mUIRootCanvasScaler = root.GetComponent<CanvasScaler>();
            UICamera = transform.Find("UICamera").GetComponent<Camera>();

            //计算标准屏幕宽高比 和 实际屏幕宽高比
            mStandardScreenRatio = mStandardWidth / (float)mStandardHeight;
            mCurScreenRatio = Screen.width / (float)Screen.height;

            //默认先进行Loading窗口的UI适配(具体情况具体对待)
            AdaptLoadingFormCanvasScaler();

            //将UIGroup信息存储到字典中
            mUIGroupDict = new Dictionary<byte, UIGroup>();
            int len = UIGroups.Length;
            for (int i = 0; i < len; i++) {
                var group = UIGroups[i];
                mUIGroupDict[group.Id] = group;
            }

            mUIManager = new UIManager();
            mUILayer = new UILayer();
            mUILayer.Init(UIGroups);
            mUIPool = new UIPool();
        }

        #region UI适配
        /// <summary>
        /// 适配Loading窗口的UI缩放
        /// </summary>
        public void AdaptLoadingFormCanvasScaler() {
            mUIRootCanvasScaler.matchWidthOrHeight = (mCurScreenRatio > mStandardScreenRatio) ? 0 : (mStandardScreenRatio - mCurScreenRatio);
        }

        /// <summary>
        /// 适配全屏窗口的UI缩放
        /// </summary>
        public void AdaptFullFormCanvasScaler() {
            mUIRootCanvasScaler.matchWidthOrHeight = 1;
        }

        /// <summary>
        /// 适配Normal窗口的UI缩放
        /// </summary>
        public void AdaptNormalFormCanvasScaler() {
            mUIRootCanvasScaler.matchWidthOrHeight = (mCurScreenRatio >= mStandardScreenRatio) ? 1 : 0;
        }

        #endregion

        /// <summary>
        /// 根据UI分组编号获取对应的UI分组
        /// </summary>
        /// <param name="id">UI分组编号</param>
        public UIGroup GetUIGroup(byte id) {
            UIGroup group = null;
            mUIGroupDict.TryGetValue(id, out group);
            return group;
        }

        /// <summary>
        /// 从UI对象池中获取UI
        /// </summary>
        public UIFormBase Dequeue(int uiFormId) {
            return mUIPool.Dequeue(uiFormId);
        }

        /// <summary>
        /// UI回池
        /// </summary>
        public void Enqueue(UIFormBase formBase) {
            mUIPool.Enqueue(formBase);
        }

        /// <summary>
        /// 打开UI窗口
        /// </summary>
        /// <param name="uiFormId">窗口ID</param>
        public void OpenUIForm(int uiFormId, object args = null) {
            mUIPool.CheckByOpenUI();
            mUIManager.OpenUIForm(uiFormId, args);
        }
        /// <summary>
        /// 打开UI窗口
        /// </summary>
        /// <param name="uiFormId">窗口ID</param>
        public void OpenUIForm<T>(int uiFormId, object args = null) where T : UIFormBase {
            mUIPool.CheckByOpenUI();
            mUIManager.OpenUIForm<T>(uiFormId, args);
        }

        /// <summary>
        /// 关闭UI窗体(通过窗体关闭)
        /// </summary>
        public void CloseUIForm(UIFormBase formBase) {
            mUIManager.CloseUIForm(formBase);
        }

        /// <summary>
        /// 关闭UI窗体(通过窗体ID关闭)
        /// </summary>
        public void CloseUIForm(int uiFormId) {
            mUIManager.CloseUIForm(uiFormId);
        }

        /// <summary>
        /// 设置层级排序
        /// </summary>
        /// <param name="formBase">要排序的UI窗体</param>
        /// <param name="isRise">层级是升高还是降低</param>
        public void SetSortingOrder(UIFormBase formBase, bool isRise = true) {
            mUILayer.SetSortingOrder(formBase, isRise);
        }


        public void OnUpdate() {
            if(Time.time > mNextRunTime + mClearInterval) {
                mNextRunTime = Time.time;
                //释放UI对象池
                mUIPool.CheckClear();
            }
        }

        public override void Shutdown() {
            
        }
    }
}
