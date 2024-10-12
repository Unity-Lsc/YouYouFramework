using System.Collections.Generic;

namespace YouYou
{
    /// <summary>
    /// 状态机
    /// </summary>
    /// <typeparam name="T">拥有者owner的类型</typeparam>
    public class Fsm<T> : FsmBase where T : class
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        private FsmState<T> mCurState;

        /// <summary>
        /// 存储状态的集合
        /// </summary>
        private Dictionary<byte, FsmState<T>> mStateDict;

        /// <summary>
        /// 存储参数的集合
        /// </summary>
        private Dictionary<string, VariableBase> mParamDict;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="fsmId">状态机编号</param>
        /// <param name="owner">状态机拥有者</param>
        /// <param name="state">状态</param>
        public Fsm(int fsmId, T owner, FsmState<T>[] states) : base(fsmId) {

            mStateDict = new Dictionary<byte, FsmState<T>>();
            mParamDict = new Dictionary<string, VariableBase>();

            //把传输进来的状态 添加进集合里面
            for (int i = 0; i < states.Length; i++) {
                FsmState<T> state = states[i];
                state.CurFsm = this;
                mStateDict[(byte)i] = state;
            }

            //设置默认状态
            CurStateType = 0;
            mCurState = mStateDict[CurStateType];
            mCurState.OnEnter();
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        public FsmState<T> GetState(byte stateType) {
            FsmState<T> state = null;
            mStateDict.TryGetValue(stateType, out state);
            return state;
        }

        public void OnUpdate() {
            if (mCurState != null) {
                mCurState.OnUpdate();
            }
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        public void ChangeState(byte newStateType) {
            //不重复进入某一个状态
            if (CurStateType == newStateType) return;

            if(mCurState != null) {
                mCurState.OnLeave();
            }
            CurStateType = newStateType;
            mCurState = mStateDict[CurStateType];
            mCurState.OnEnter();
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <typeparam name="TParam">参数类型</typeparam>
        public void SetParam<TParam>(string key, TParam value) {
            VariableBase var = null;
            Variable<TParam> item;
            if (mParamDict.TryGetValue(key, out var)) {
                item = var as Variable<TParam>;
            } else {
                //参数原来不存在
                item = new Variable<TParam>();
            }
            item.Value = value;
            mParamDict[key] = item;
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="TParam">参数的类型</typeparam>
        public TParam GetParam<TParam>(string key) {
            VariableBase var = null;
            if (mParamDict.TryGetValue(key, out var)) {
                Variable<TParam> item = var as Variable<TParam>;
                return item.Value;
            }
            return default(TParam);
        }

        /// <summary>
        /// 关闭状态机
        /// </summary>
        public override void ShutDown() {
            if(mCurState != null) {
                mCurState.OnLeave();
            }

            foreach (KeyValuePair<byte, FsmState<T>> state in mStateDict) {
                state.Value.OnDestroy();
            }
            mStateDict.Clear();
            mParamDict.Clear();
        }
    }
}
