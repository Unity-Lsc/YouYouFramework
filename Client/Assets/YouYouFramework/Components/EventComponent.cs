
namespace YouYou
{
    /// <summary>
    /// 事件组件
    /// </summary>
    public class EventComponent : YouYouBaseComponent
    {

        private EventManager mEventManager;

        public SocketEvent SocketEvent;
        public CommonEvent CommonEvent;

        protected override void OnAwake() {
            base.OnAwake();
            mEventManager = new EventManager();
            SocketEvent = mEventManager.SocketEvent;
            CommonEvent = mEventManager.CommonEvent;
        }

        

        public override void Shutdown() {
            mEventManager.Dispose();
            mEventManager = null;
        }
    }
}
