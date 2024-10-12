using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// bool变量
    /// </summary>
    public class VarBool : Variable<bool>{

        /// <summary>
        /// 分配一个对象
        /// </summary>
        public static VarBool Alloc() {
            VarBool var = GameEntry.Pool.DequeueVarObject<VarBool>();
            var.Value = false;
            var.Retain();
            return var;
        }
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarBool Alloc(bool value) {
            VarBool var = Alloc();
            var.Value = value;
            return var;
        }
        /// <summary>
        /// VarBool -> bool
        /// </summary>
        public static implicit operator bool(VarBool value) {
            return value.Value;
        }

    }
}
