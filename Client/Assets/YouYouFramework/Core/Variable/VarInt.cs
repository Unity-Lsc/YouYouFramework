using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// int变量
    /// </summary>
    public class VarInt : Variable<int>
    {
        /// <summary>
        /// 分配一个对象
        /// </summary>
        public static VarInt Alloc() {
            VarInt var = GameEntry.Pool.DequeueVarObject<VarInt>();
            var.Value = 0;
            var.Retain();
            return var;
        }

        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarInt Alloc(int value) {
            VarInt var = Alloc();
            var.Value = value;
            return var;
        }

        /// <summary>
        /// VarInt -> int
        /// </summary>
        public static implicit operator int(VarInt param) {
            return param.Value;
        }

    }
}
