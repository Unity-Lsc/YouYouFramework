using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// byte[]变量
    /// </summary>
    public class VarBytes : Variable<byte[]>
    {

        /// <summary>
        /// 分配一个对象
        /// </summary>
        public static VarBytes Alloc() {
            VarBytes var = GameEntry.Pool.DequeueVarObject<VarBytes>();
            var.Value = null;
            var.Retain();
            return var;
        }

        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarBytes Alloc(byte[] value) {
            VarBytes var = Alloc();
            var.Value = value;
            return var;
        }

        /// <summary>
        /// VarBytes -> byte[]
        /// </summary>
        public static implicit operator byte[](VarBytes value) {
            return value.Value;
        }

    }
}
