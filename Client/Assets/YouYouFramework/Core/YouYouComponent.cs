using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 组件基类
    /// </summary>
    public class YouYouComponent : MonoBehaviour
    {
        /// <summary>
        /// 组件的实例编号
        /// </summary>
        private int mInstanceId;
        public int InstanceId { get { return mInstanceId; } }

        private void Awake() {
            mInstanceId = GetInstanceID();

            //子类Awake要做的事
            OnAwake();
        }

        private void Start() {
            OnStart();
        }

        protected virtual void OnAwake() {  }

        protected virtual void OnStart() { }


    }
}
