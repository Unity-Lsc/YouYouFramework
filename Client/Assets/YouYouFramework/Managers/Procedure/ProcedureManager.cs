using System;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 流程状态
    /// </summary>
    public enum ProcedureState {
        Launch = 0,
        CheckVersion = 1,
        Preload = 2,
        ChangeScene = 3,
        LogOn = 4,
        SelectRole = 5,
        EnterGame = 6,
        WorldMap = 7,
        GameLevel = 8
    }

    /// <summary>
    /// 流程 管理器
    /// </summary>
    public class ProcedureManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// 流程状态机器
        /// </summary>
        private Fsm<ProcedureManager> mCurFsm;
        public Fsm<ProcedureManager> CurFsm {
            get { return mCurFsm; }
        }

        /// <summary>
        /// 当前的流程状态(ProcedureState枚举)
        /// </summary>
        public ProcedureState CurProcedureState {
            get { return (ProcedureState)mCurFsm.CurStateType; }
        }

        /// <summary>
        /// 当前的流程(流程对应的类的实例)
        /// </summary>
        public FsmState<ProcedureManager> CurProcedure {
            get { return mCurFsm.GetState(mCurFsm.CurStateType); }
        }

        public ProcedureManager() {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            FsmState<ProcedureManager>[] states = new FsmState<ProcedureManager>[9];
            states[0] = new ProcedureLaunch();
            states[1] = new ProcedureCheckVersion();
            states[2] = new ProcedurePreload();
            states[3] = new ProcedureChangeScene();
            states[4] = new ProcedureLogOn();
            states[5] = new ProcedureSelectRole();
            states[6] = new ProcedureEnterGame();
            states[7] = new ProcedureWorldMap();
            states[8] = new ProcedureGameLevel();

            mCurFsm = GameEntry.Fsm.CreateFsm(this, states);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        public void ChangeState(ProcedureState state) {
            mCurFsm.ChangeState((byte)state);
        }

        public void OnUpdate() {
            mCurFsm.OnUpdate();
        }

        public void Dispose() {
            
        }
    }
}
