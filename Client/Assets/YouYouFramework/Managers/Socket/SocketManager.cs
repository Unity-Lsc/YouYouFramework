using System;
using System.Collections.Generic;

namespace YouYou
{
    /// <summary>
    /// Socket 管理器
    /// </summary>
    public class SocketManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// SocketTcp访问器的链表
        /// </summary>
        private LinkedList<SocketTcpRoutine> mSocketTcpRoutineList;

        public SocketManager() {
            mSocketTcpRoutineList = new LinkedList<SocketTcpRoutine>();
        }

        /// <summary>
        /// 注册SocketTcp访问器
        /// </summary>
        internal void RegisterSocketTcpRoutine(SocketTcpRoutine routine) {
            mSocketTcpRoutineList.AddFirst(routine);
        }

        /// <summary>
        /// 移除SocketTcp访问器
        /// </summary>
        internal void RemoveSocketTcpRoutine(SocketTcpRoutine routine) {
            mSocketTcpRoutineList.Remove(routine);
        }

        internal void OnUpdate() {
            for (LinkedListNode<SocketTcpRoutine> curRoutine = mSocketTcpRoutineList.First; curRoutine!=null; curRoutine = curRoutine.Next) {
                curRoutine.Value.OnUpdate();
            }
        }

        public void Dispose() {
            mSocketTcpRoutineList.Clear();
        }
    }
}
