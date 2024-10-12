using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 基础组件基类
    /// </summary>
    public abstract class YouYouBaseComponent : YouYouComponent
    {

        protected override void OnAwake() {
            base.OnAwake();

            //把自己注册到基础组件列表中
            GameEntry.RegisterBaseComponent(this);
        }

        protected override void OnStart() {
            base.OnStart();
        }


        /// <summary>
        /// 关闭基础组件
        /// </summary>
        public abstract void Shutdown();

    }
}
