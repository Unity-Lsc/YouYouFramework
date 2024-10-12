using System.Collections.Generic;

namespace YouYou
{
    /// <summary>
    /// 状态机 管理器
    /// </summary>
    public class FsmManager : ManagerBase, System.IDisposable
    {

        /// <summary>
        /// 存储状态机的集合
        /// </summary>
        private Dictionary<int, FsmBase> mFsmDict;

        public FsmManager() {
            mFsmDict = new Dictionary<int, FsmBase>();
        }

        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <typeparam name="T">拥有者的类型</typeparam>
        /// <param name="fsmId">状态机的编号</param>
        /// <param name="owner">拥有者</param>
        /// <param name="states">状态机的状态数组</param>
        public Fsm<T> CreateFsm<T>(int fsmId, T owner, FsmState<T>[] states) where T : class {
            Fsm<T> fsm = new Fsm<T>(fsmId, owner, states);
            mFsmDict[fsmId] = fsm;
            return fsm;
        }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        public void DestroyFsm(int fsmId) {
            FsmBase fsm = null;
            if(mFsmDict.TryGetValue(fsmId, out fsm)) {
                fsm.ShutDown();
                mFsmDict.Remove(fsmId);
            }
        }

        public void Dispose() {
            var enumerator = mFsmDict.GetEnumerator();
            while (enumerator.MoveNext()) {
                enumerator.Current.Value.ShutDown();
            }
            mFsmDict.Clear();
        }
    }
}
