using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// float变量
    /// </summary>
    public class VarFloat : Variable<float>
    {

        /// <summary>
        /// 分配一个对象
        /// </summary>
        public static VarFloat Alloc() {
            VarFloat var = GameEntry.Pool.DequeueVarObject<VarFloat>();
            var.Value = 0f;
            var.Retain();
            return var;
        }
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarFloat Alloc(float value) {
            VarFloat var = Alloc();
            var.Value = value;
            return var;
        }
        /// <summary>
        /// VarFloat -> float
        /// </summary>
        public static implicit operator float(VarFloat value) {
            return value.Value;
        }

    }
}
