
using System;

namespace YouYou
{
    /// <summary>
    /// 对象池 管理器
    /// </summary>
    public class PoolManager : ManagerBase, IDisposable
    {

        public ClassObjectPool ClassObjectPool { private set; get; }

        public GameObjectPool GameObjectPool { private set; get; }

        public PoolManager() {
            ClassObjectPool = new ClassObjectPool();
            GameObjectPool = new GameObjectPool();
        }

        /// <summary>
        /// 释放类对象池
        /// </summary>
        public void ReleaseClassObjectPool() {
            ClassObjectPool.ReleaseClassObjectPool();
        }

        public void Dispose() {
            ClassObjectPool.Dispose();
            GameObjectPool.Dispose();
        }
    }
}
