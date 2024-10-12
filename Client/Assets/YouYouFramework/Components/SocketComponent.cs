
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Socket组件
    /// </summary>
    public class SocketComponent : YouYouBaseComponent, IUpdateComponent
    {

        private SocketManager mSocketManager;

        /// <summary>
        /// 通用的MemoryStream
        /// </summary>
        public MMO_MemoryStream CommonMemoryStream { get; private set; }

        /// <summary>
        /// 每帧最大发送数量
        /// </summary>
        [Header("每帧最大发送数量")]
        public int MaxSendCount = 5;
        /// <summary>
        /// 每次发包最大的字节
        /// </summary>
        [Header("每次发包最大的字节")]
        public int MaxSendByteCount = 1024;

        /// <summary>
        /// 每帧最大处理包数量
        /// </summary>
        [Header("每帧最大处理包数量")]
        public int MaxReceiveCount = 5;

        /// <summary>
        /// 主Socket
        /// </summary>
        private SocketTcpRoutine mMainSocketRoutine;

        protected override void OnAwake() {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            mSocketManager = new SocketManager();
            CommonMemoryStream = new MMO_MemoryStream();
        }

        protected override void OnStart() {
            base.OnStart();
            mMainSocketRoutine = CreateSocketTcpRoutine();
            SocketProtoListener.AddProtoListener();
        }

        public void OnUpdate() {
            mSocketManager.OnUpdate();
        }

        /// <summary>
        /// 注册SocketTcp访问器
        /// </summary>
        internal void RegisterSocketTcpRoutine(SocketTcpRoutine routine) {
            mSocketManager.RegisterSocketTcpRoutine(routine);
        }

        /// <summary>
        /// 移除SocketTcp访问器
        /// </summary>
        internal void RemoveSocketTcpRoutine(SocketTcpRoutine routine) {
            mSocketManager.RemoveSocketTcpRoutine(routine);
        }

        /// <summary>
        /// 创建SocketTcp访问器
        /// </summary>
        public SocketTcpRoutine CreateSocketTcpRoutine() {
            //从池中获取
            return GameEntry.Pool.DequeueClassObject<SocketTcpRoutine>();
        }

        public override void Shutdown() {
            mSocketManager.Dispose();
            GameEntry.Pool.EnqueueClassObject(mMainSocketRoutine);
            SocketProtoListener.RemoveProtoListener();

            CommonMemoryStream.Dispose();
            CommonMemoryStream.Close();
        }

        /// <summary>
        /// 连接主Socket
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        public void ConnectToMainSocket(string ip, int port) {
            mMainSocketRoutine.Connect(ip, port);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        public void SendMsg(byte[] buffer) {
            mMainSocketRoutine.SendMsg(buffer);
        }

        
    }
}
