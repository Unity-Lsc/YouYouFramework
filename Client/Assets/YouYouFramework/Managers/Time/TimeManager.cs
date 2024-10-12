using System;
using System.Collections.Generic;

namespace YouYou
{
    /// <summary>
    /// 时间 管理器
    /// </summary>
    public class TimeManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// 定时器集合
        /// </summary>
        private LinkedList<TimeAction> mTimeActionLst;

        public TimeManager() {
            mTimeActionLst = new LinkedList<TimeAction>();
        }

        /// <summary>
        /// 注册定时器
        /// </summary>
        /// <param name="action">要注册的定时器</param>
        internal void RegisterTimeAction(TimeAction action) {
            mTimeActionLst.AddLast(action);
        }

        /// <summary>
        /// 移除定时器
        /// </summary>
        /// <param name="action">要移除的定时器</param>
        internal void RemoveTimeAction(TimeAction action) {
            mTimeActionLst.Remove(action);
        }

        internal void OnUpdate() {
            LinkedListNode<TimeAction> curTime;
            for(curTime = mTimeActionLst.First; curTime != null; curTime = curTime.Next) {
                curTime.Value.OnUpdate();
            }
        }

        public void Dispose() {
            mTimeActionLst.Clear();
        }
    }
}
