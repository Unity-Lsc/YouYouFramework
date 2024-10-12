using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 检查更新流程
    /// </summary>
    public class ProcedureCheckVersion : ProcedureBase
    {
        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("OnEnter ProcedureCheckVersion");

            GameEntry.Procedure.ChangeState(ProcedureState.Preload);
        }

        public override void OnUpdate() {
            base.OnUpdate();
        }

        public override void OnLeave() {
            base.OnLeave();
        }

        public override void OnDestroy() {
            base.OnDestroy();
        }


    }
}
