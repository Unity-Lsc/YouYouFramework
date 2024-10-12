using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// byte变量
    /// </summary>
    public class VarByte : Variable<byte>
    {
        /// <summary>
        /// 分配一个对象
        /// </summary>
        public static VarByte Alloc() {
            VarByte var = GameEntry.Pool.DequeueVarObject<VarByte>();
            var.Value = 0;
            var.Retain();
            return var;
        }
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarByte Alloc(byte value) {
            VarByte var = Alloc();
            var.Value = value;
            return var;
        }
        /// <summary>
        /// VarByte -> byte
        /// </summary>
        public static implicit operator byte(VarByte value) {
            return value.Value;
        }

    }
}
