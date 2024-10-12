
namespace YouYou
{
    /// <summary>
    /// 状态机组件
    /// </summary>
    public class FsmComponent : YouYouBaseComponent
    {
        /// <summary>
        /// 状态机管理器
        /// </summary>
        private FsmManager mFsmManager;

        /// <summary>
        /// 状态机的临时编号
        /// </summary>
        private int mTemFsmId = 0;

        protected override void OnAwake() {
            base.OnAwake();
            mFsmManager = new FsmManager();
        }

        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <typeparam name="T">拥有者owner的类型</typeparam>
        /// <param name="owner">拥有者</param>
        /// <param name="states">状态数组</param>
        public Fsm<T> CreateFsm<T>(T owner, FsmState<T>[] states) where T : class {
            return mFsmManager.CreateFsm(mTemFsmId++, owner, states);
        }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        public void DestroyFsm(int fsmId) {
            mFsmManager.DestroyFsm(fsmId);
        }

        public override void Shutdown() {
            mFsmManager.Dispose();
        }
    }
}
