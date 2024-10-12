using System.Collections.Generic;

namespace YouYou
{
    /// <summary>
    /// 流程组件
    /// </summary>
    public class ProcedureComponent : YouYouBaseComponent, IUpdateComponent
    {

        private ProcedureManager mProcedureManager;

        /// <summary>
        /// 当前的流程状态(ProcedureState枚举)
        /// </summary>
        public ProcedureState CurProcedureState {
            get { return mProcedureManager.CurProcedureState; }
        }

        /// <summary>
        /// 当前的流程(流程对应的类的实例)
        /// </summary>
        public FsmState<ProcedureManager> CurProcedure {
            get { return mProcedureManager.CurProcedure; }
        }

        protected override void OnAwake() {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            mProcedureManager = new ProcedureManager();
        }

        protected override void OnStart() {
            base.OnStart();
            mProcedureManager.Init();
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <typeparam name="TParam">参数类型</typeparam>
        public void SetParam<TParam>(string key, TParam value) {
            mProcedureManager.CurFsm.SetParam<TParam>(key, value);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="TParam">参数的类型</typeparam>
        public TParam GetParam<TParam>(string key) {
            return mProcedureManager.CurFsm.GetParam<TParam>(key);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(ProcedureState state) {
            mProcedureManager.ChangeState(state);
        }

        public void OnUpdate() {
            mProcedureManager.OnUpdate();
        }

        public override void Shutdown() {
            mProcedureManager.Dispose();
        }
    }
}
