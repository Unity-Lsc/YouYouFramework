using PathologicalGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 游戏物体对象池实体
    /// </summary>
    [System.Serializable]
    public class GameObjectPoolEntity
    {
        /// <summary>
        /// 对象池编号
        /// </summary>
        public byte PoolID;

        /// <summary>
        /// 对象池名字
        /// </summary>
        public string PoolName;

        /// <summary>
        /// 是否开始缓存池的自动清理模式
        /// </summary>
        public bool IsCullDespawned = false;

        /// <summary>
        /// 缓存池自动清理时,始终保留不清理的数量
        /// </summary>
        public int CullAbove = 5;

        /// <summary>
        /// 缓存池进行自动清理的时间间隔(单位秒)
        /// </summary>
        public int CullDelay = 2;

        /// <summary>
        /// 缓存池每次进行自动清理的数量
        /// </summary>
        public int CullMaxPerPass = 2;

        /// <summary>
        /// 对应的游戏物体对象池
        /// </summary>
        public SpawnPool Pool;

    }
}
