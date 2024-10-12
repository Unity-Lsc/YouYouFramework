using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 启动流程
    /// </summary>
    public class ProcedureLaunch : ProcedureBase
    {

        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("OnEnter ProcedureLaunch");

            ////访问帐号服务器
            //string url = GameEntry.Http.RealWebAccountUrl + "/api/init";

            //Dictionary<string, object> dict = GameEntry.Pool.DequeueClassObject<Dictionary<string, object>>();
            //dict.Clear();
            //dict["ChannelId"] = 0;
            //dict["InnerVersion"] = 1001;
            //GameEntry.Http.SendData(url, OnWebAccountInit, true, dict);

            var action = GameEntry.Time.CreateTimeAction();
            action.Init(0.5f, () => {
                ToCheckVersion();
            });
            action.Run();
        }

        private void OnWebAccountInit(HttpCallBackArgs args) {
            
        }

        /// <summary>
        /// 切换到检查版本更新的状态(测试使用)
        /// </summary>
        private void ToCheckVersion() {
            GameEntry.Procedure.ChangeState(ProcedureState.CheckVersion);
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
