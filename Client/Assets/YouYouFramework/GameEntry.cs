using System;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou 
{
    /// <summary>
    /// 项目启动入口
    /// </summary>
    public class GameEntry : MonoBehaviour
    {

        #region 组件属性

        public static EventComponent Event { get; private set; }
        public static TimeComponent Time { get; private set; }
        public static FsmComponent Fsm { get; private set; }
        public static ProcedureComponent Procedure { get; private set; }
        public static DataTableComponent DataTable { get; private set; }
        public static SocketComponent Socket { get; private set; }
        public static HttpComponent Http { get; private set; }
        public static DataComponent Data { get; private set; }
        public static LocalizationComponent Localization { get; private set; }
        public static PoolComponent Pool { get; private set; }
        public static SceneComponent Scene { get; private set; }
        public static SettingComponent Setting { get; private set; }
        public static GameObjComponent GameObj { get; private set; }
        public static ResourceComponent Resource { get; private set; }
        public static DownloadComponent Download { get; private set; }
        public static UIComponent UI { get; private set; }

        public static LuaComponent Lua { get; private set; }

        #endregion

        /// <summary>
        /// 基础组件 列表
        /// </summary>
        private static readonly LinkedList<YouYouBaseComponent> mBaseCompanentList = new LinkedList<YouYouBaseComponent>();

        /// <summary>
        /// 更新组件 列表
        /// </summary>
        private static readonly LinkedList<IUpdateComponent> mUpdateCompanentList = new LinkedList<IUpdateComponent>();
        

        private void Start() {
            InitBaseComponents();
        }

        private void Update() {
            //循环 更新组件
            for (LinkedListNode<IUpdateComponent> curComp = mUpdateCompanentList.First; curComp != null; curComp = curComp.Next) {
                curComp.Value.OnUpdate();
            }
        }

        private void OnDestroy() {
            //关闭所有的基础组件
            for (LinkedListNode<YouYouBaseComponent> curComp = mBaseCompanentList.First; curComp != null; curComp = curComp.Next) {
                curComp.Value.Shutdown();
            }
        }

        #region 基础组件相关

        /// <summary>
        /// 初始化基础组件
        /// </summary>
        private void InitBaseComponents() {
            //Debug.Log("初始化基础组件");
            //Debug.Log(mBaseCompanentList.Count);
            Event = GetBaseComponent<EventComponent>();
            Time = GetBaseComponent<TimeComponent>();
            Fsm = GetBaseComponent<FsmComponent>();
            Procedure = GetBaseComponent<ProcedureComponent>();
            DataTable = GetBaseComponent<DataTableComponent>();
            Socket = GetBaseComponent<SocketComponent>();
            Http = GetBaseComponent<HttpComponent>();
            Data = GetBaseComponent<DataComponent>();
            Localization = GetBaseComponent<LocalizationComponent>();
            Pool = GetBaseComponent<PoolComponent>();
            Scene = GetBaseComponent<SceneComponent>();
            Setting = GetBaseComponent<SettingComponent>();
            GameObj = GetBaseComponent<GameObjComponent>();
            Resource = GetBaseComponent<ResourceComponent>();
            Download = GetBaseComponent<DownloadComponent>();
            UI = GetBaseComponent<UIComponent>();
            Lua = GetBaseComponent<LuaComponent>();
        }

        /// <summary>
        /// 注册基础组件
        /// </summary>
        /// <param name="component">要注册的基础组件</param>
        internal static void RegisterBaseComponent(YouYouBaseComponent component) {
            //获取到组件类型
            Type type = component.GetType();
            LinkedListNode<YouYouBaseComponent> curComponent = mBaseCompanentList.First;
            while (curComponent != null) {
                if (curComponent.Value.GetType() == type) return;
                curComponent = curComponent.Next;
            }

            //把组件加入最后一个节点
            mBaseCompanentList.AddLast(component);
            //Debug.Log("注册:" + component.GetType().Name);

        }

        /// <summary>
        /// 获取基础组件
        /// </summary>
        /// <param name="type">要获取的基础组件类型</param>
        internal static YouYouBaseComponent GetBaseComponent(Type type) {
            LinkedListNode<YouYouBaseComponent> curComponent = mBaseCompanentList.First;
            while (curComponent != null) {
                if (curComponent.Value.GetType() == type) return curComponent.Value;
                curComponent = curComponent.Next;
            }
            return null;
        }

        /// <summary>
        /// 获取组件类型(通过泛型获取)
        /// </summary>
        internal static T GetBaseComponent<T>() where T : YouYouBaseComponent {
            return (T)GetBaseComponent(typeof(T));
        }

        #endregion


        #region 更新组件相关

        /// <summary>
        /// 注册 更新组件
        /// </summary>
        /// <param name="component">要注册的 更新组件</param>
        public static void RegisterUpdateComponent(IUpdateComponent component) {
            mUpdateCompanentList.AddLast(component);
        }

        /// <summary>
        /// 移除 更新组件
        /// </summary>
        /// <param name="component">要移除的 更新组件</param>
        public static void RemoveUpdateComponent(IUpdateComponent component) {
            mUpdateCompanentList.Remove(component);
        }

        #endregion

    }

}
