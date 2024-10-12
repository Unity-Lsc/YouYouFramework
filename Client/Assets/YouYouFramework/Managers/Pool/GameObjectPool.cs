using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 游戏物体对象池
    /// </summary>
    public class GameObjectPool : IDisposable
    {
        /// <summary>
        /// 游戏物体对象池集合
        /// </summary>
        private Dictionary<byte, GameObjectPoolEntity> mSpawnPoolDict;

        public GameObjectPool() {
            mSpawnPoolDict = new Dictionary<byte, GameObjectPoolEntity>();
        }

        /// <summary>
        /// 初始化游戏物体对象池
        /// </summary>
        public IEnumerator Init(GameObjectPoolEntity[] arr, Transform parent) {
            int len = arr.Length;
            for (int i = 0; i < len; i++) {
                GameObjectPoolEntity entity = arr[i];
                if(entity.Pool != null) {
                    UnityEngine.Object.Destroy(entity.Pool.gameObject);
                    yield return null;
                    entity.Pool = null;
                }
                //创建对象池
                PathologicalGames.SpawnPool pool = PathologicalGames.PoolManager.Pools.Create(entity.PoolName);
                pool.group.parent = parent;
                pool.group.localPosition = Vector3.zero;
                entity.Pool = pool;

                mSpawnPoolDict[entity.PoolID] = entity;
            }
        }

        /// <summary>
        /// 从游戏对象池中获取对象
        /// </summary>
        public void Spawn(byte poolId, Transform prefab, Action<Transform> onComplete = null) {

            GameObjectPoolEntity entity = mSpawnPoolDict[poolId];
            //拿到预设池
            PathologicalGames.PrefabPool prefabPool = entity.Pool.GetPrefabPool(prefab);
            if(prefabPool == null) {
                prefabPool = new PathologicalGames.PrefabPool(prefab);
                prefabPool.cullDespawned = entity.IsCullDespawned;
                prefabPool.cullAbove = entity.CullAbove;
                prefabPool.cullDelay = entity.CullDelay;
                prefabPool.cullMaxPerPass = entity.CullMaxPerPass;

                entity.Pool.CreatePrefabPool(prefabPool);
            }

            if(onComplete != null) {
                onComplete(entity.Pool.Spawn(prefab));
            }

        }

        /// <summary>
        /// 游戏物体对象池 回池
        /// </summary>
        public void Despawn(byte poolId, Transform instance) {
            GameObjectPoolEntity entity = mSpawnPoolDict[poolId];
            entity.Pool.Despawn(instance);
        }

        public void Dispose() {
            mSpawnPoolDict.Clear();
        }

    }
}
