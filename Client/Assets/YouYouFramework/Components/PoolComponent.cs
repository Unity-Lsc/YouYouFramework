using System;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 对象池组件
    /// </summary>
    public class PoolComponent : YouYouBaseComponent, IUpdateComponent
    {

        public PoolManager PoolManager { private set; get; }

        protected override void OnAwake() {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);

            PoolManager = new PoolManager();

            mNextRunTime = Time.time;
            
            InitGameObjectPool();
            
        }

        protected override void OnStart() {
            base.OnStart();
            InitResidentCount();
        }

        /// <summary>
        /// 初始化常用类的常驻数量
        /// </summary>
        private void InitResidentCount() {
            SetClassObjectResidentCount<HttpRoutine>(3);
            SetClassObjectResidentCount<Dictionary<string, object>>(3);
        }

        #region 类对象池相关

        /// <summary>
        /// 从类对象池中取出对象
        /// </summary>
        public T DequeueClassObject<T>() where T : class,new() {
            return PoolManager.ClassObjectPool.Dequeue<T>();
        }

        /// <summary>
        /// 回收对象进 类对象池
        /// </summary>
        public void EnqueueClassObject(object obj) {
            PoolManager.ClassObjectPool.Enqueue(obj);
        }

        /// <summary>
        /// 设置类对象池的常驻数量
        /// </summary>
        public void SetClassObjectResidentCount<T>(byte count) where T : class {
            PoolManager.ClassObjectPool.SetResidentCount<T>(count);
        }

        #endregion

        #region 类对象池编辑器面板相关

        /// <summary>
        /// 释放的时间间隔
        /// </summary>
        public int ClearInterval = 0;

        /// <summary>
        /// 下次运行时间
        /// </summary>
        private float mNextRunTime = 0f;

        public void OnUpdate() {
            if(Time.time > mNextRunTime + ClearInterval) {
                //该释放了
                mNextRunTime = Time.time;
                PoolManager.ReleaseClassObjectPool();
            }
        }

        #endregion


        #region 变量对象池相关

        /// <summary>
        /// 变量对象池锁
        /// </summary>
        private object mVarObjectLock = new object();

#if UNITY_EDITOR
        /// <summary>
        /// 变量对象池 在编辑器面板上 显示的数量
        /// </summary>
        public Dictionary<Type, int> VarObjectInspectorDict = new Dictionary<Type, int>();
#endif

        /// <summary>
        /// 从变量对象池中取出一个变量对象
        /// </summary>
        public T DequeueVarObject<T>() where T : VariableBase, new() {
            lock (mVarObjectLock) {
                T item = DequeueClassObject<T>();
#if UNITY_EDITOR
                Type t = item.GetType();
                if (VarObjectInspectorDict.ContainsKey(t)) {
                    VarObjectInspectorDict[t]++;
                } else {
                    VarObjectInspectorDict[t] = 1;
                }
#endif
                return item;
            }
        }

        /// <summary>
        /// 变量对象回池
        /// </summary>
        public void EnqueueVarObject<T>(T item) where T : VariableBase {
            lock (mVarObjectLock) {
                EnqueueClassObject(item);
#if UNITY_EDITOR
                Type t = item.GetType();
                if (VarObjectInspectorDict.ContainsKey(t)) {
                    VarObjectInspectorDict[t]--;
                    if(VarObjectInspectorDict[t] <= 0) {
                        VarObjectInspectorDict.Remove(t);
                    }
                }
#endif
            }
        }

        #endregion


        #region 游戏物体对象池相关

        /// <summary>
        /// 游戏物体对象池分组
        /// </summary>
        [SerializeField]
        private GameObjectPoolEntity[] mGameObjectPoolEntityGroup;

        /// <summary>
        /// 初始化游戏物体对象池
        /// </summary>
        public void InitGameObjectPool() {
            StartCoroutine(PoolManager.GameObjectPool.Init(mGameObjectPoolEntityGroup, transform));
        }

        /// <summary>
        /// 从对象池中获取游戏对象
        /// </summary>
        public void GameObjectSpawn(byte poolId, Transform prefab, Action<Transform> onComplete) {
            PoolManager.GameObjectPool.Spawn(poolId, prefab, onComplete);
        }

        /// <summary>
        /// 对象回池
        /// </summary>
        public void GameObjectDespawn(byte poolId, Transform instance) {
            PoolManager.GameObjectPool.Despawn(poolId, instance);
        }

        #endregion

        /// <summary>
        /// 关闭组件
        /// </summary>
        public override void Shutdown() {
            PoolManager.Dispose();
        }

    }
}
