using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 时间组件
    /// </summary>
    public class TimeComponent : YouYouBaseComponent, IUpdateComponent
    {
        //定时器管理器
        private TimeManager mTimeManager;

        protected override void OnAwake() {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);

            mTimeManager = new TimeManager();
        }

        public void OnUpdate() {
            mTimeManager.OnUpdate();
        }

        /// <summary>
        /// 创建 定时器类
        /// </summary>
        public TimeAction CreateTimeAction() {
            return GameEntry.Pool.DequeueClassObject<TimeAction>();
        }

        /// <summary>
        /// 注册定时器
        /// </summary>
        /// <param name="action">要注册的定时器</param>
        internal void RegisterTimeAction(TimeAction action) {
            mTimeManager.RegisterTimeAction(action);
        }

        /// <summary>
        /// 移除定时器
        /// </summary>
        /// <param name="action">要移除的定时器</param>
        internal void RemoveTimeAction(TimeAction action) {
            mTimeManager.RemoveTimeAction(action);
            GameEntry.Pool.EnqueueClassObject(action);
        }

        public override void Shutdown() {
            mTimeManager.Dispose();
        }
    }
}
