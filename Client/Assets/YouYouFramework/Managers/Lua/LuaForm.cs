using System;
using UnityEngine;
using UnityEngine.UI;
using XLua;

namespace YouYou
{
    /// <summary>
    /// Lua窗口
    /// </summary>
    [LuaCallCSharp]
    public class LuaForm : UIFormBase
    {

        [CSharpCallLua]
        public delegate void OnInitHandler(Transform transform, object userData);
        private OnInitHandler mOnInit;
        [CSharpCallLua]
        public delegate void OnOpenHandler(object userData);
        private OnOpenHandler mOnOpen;
        [CSharpCallLua]
        public delegate void OnCloseHandler();
        private OnCloseHandler mOnClose;
        [CSharpCallLua]
        public delegate void OnBeforeDestroyHandler();
        private OnBeforeDestroyHandler mOnBeforeDestroy;

        private LuaTable mScriptEnv;
        private LuaEnv mLuaEnv;

        [Header("Lua组件")]
        [SerializeField]
        private LuaComp[] mLuaComps;
        public LuaComp[] LuaComps { get { return mLuaComps; } }

        protected override void OnInit(object userData) {
            base.OnInit(userData);
            //从LuaManager中获取，全局只有一个
            mLuaEnv = LuaManager.luaEnv;
            if (mLuaEnv == null) return;

            mScriptEnv = mLuaEnv.NewTable();

            LuaTable meta = mLuaEnv.NewTable();
            meta.Set("__index", mLuaEnv.Global);
            mScriptEnv.SetMetaTable(meta);
            meta.Dispose();

            string prefabName = name;
            if (prefabName.Contains("(Clone)")) {
                prefabName = prefabName.Split(new string[] { "(Clone)" }, StringSplitOptions.RemoveEmptyEntries)[0] + "View";
            }

            mOnInit = mScriptEnv.GetInPath<OnInitHandler>(prefabName + ".OnInit");
            mOnOpen = mScriptEnv.GetInPath<OnOpenHandler>(prefabName + ".OnOpen");
            mOnClose = mScriptEnv.GetInPath<OnCloseHandler>(prefabName + ".OnClose");
            mOnBeforeDestroy = mScriptEnv.GetInPath<OnBeforeDestroyHandler>(prefabName + ".OnBeforeDestory");

            mScriptEnv.Set("self", this);
            if(mOnInit != null) {
                mOnInit(transform, userData);
            }

        }

        /// <summary>
        /// 根据索引查找组件
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>对应的组件</returns>
        public object GetLuaComp(int index) {
            LuaComp comp = mLuaComps[index];
            Transform compTran = comp.Tran;
            switch (comp.Type) {
                case LuaCompType.GameObject: return compTran.gameObject;
                case LuaCompType.Transform: return compTran;
                case LuaCompType.Button: return compTran.GetComponent<Button>();
                case LuaCompType.Image: return compTran.GetComponent<Image>();
                case LuaCompType.LocalizationImage: return compTran.GetComponent<LocalizationImage>();
                case LuaCompType.Text: return compTran.GetComponent<Text>();
                case LuaCompType.LocalizationText: return compTran.GetComponent<LocalizationText>();
                case LuaCompType.RawImage: return compTran.GetComponent<RawImage>();
                case LuaCompType.InputField: return compTran.GetComponent<InputField>();
                case LuaCompType.Scrollbar: return compTran.GetComponent<Scrollbar>();
                case LuaCompType.ScrollRect: return compTran.GetComponent<ScrollRect>();
                case LuaCompType.UIMultiScroller: return compTran.GetComponent<UIMultiScroller>();
                case LuaCompType.UIScroller: return compTran.GetComponent<UIScroller>();
            }
            return compTran;
        }

        protected override void OnOpen(object userData) {
            base.OnOpen(userData);
            if (mOnOpen != null) {
                mOnOpen(userData);
            }
        }

        protected override void OnClose() {
            base.OnClose();
            if (mOnClose != null) {
                mOnClose();
            }
        }

        protected override void OnBeforeDestory() {
            base.OnBeforeDestory();
            if (mOnBeforeDestroy != null) {
                mOnBeforeDestroy();
            }

            mOnInit = null;
            mOnOpen = null;
            mOnClose = null;
            mOnBeforeDestroy = null;

        }

    }



}
