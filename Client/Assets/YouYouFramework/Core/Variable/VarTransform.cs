using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Transform变量
    /// </summary>
    public class VarTransform : Variable<Transform>
    {

        /// <summary>
        /// 分配一个对象
        /// </summary>
        public static VarTransform Alloc() {
            VarTransform var = GameEntry.Pool.DequeueVarObject<VarTransform>();
            var.Value = null;
            var.Retain();
            return var;
        }
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarTransform Alloc(Transform value) {
            VarTransform var = Alloc();
            var.Value = value;
            return var;
        }
        /// <summary>
        /// VarTransform -> Transform
        /// </summary>
        public static implicit operator Transform(VarTransform value) {
            return value.Value;
        }

    }
}
