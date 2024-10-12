using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Color变量
    /// </summary>
    public class VarColor : Variable<Color>
    {

        /// <summary>
        /// 分配一个对象(默认为黑色)
        /// </summary>
        public static VarColor Alloc() {
            VarColor var = GameEntry.Pool.DequeueVarObject<VarColor>();
            var.Value = Color.black;
            var.Retain();
            return var;
        }

        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarColor Alloc(Color value) {
            VarColor var = Alloc();
            var.Value = value;
            return var;
        }

        /// <summary>
        /// VarColor -> Color
        /// </summary>
        public static implicit operator Color(VarColor param) {
            return param.Value;
        }

    }
}
