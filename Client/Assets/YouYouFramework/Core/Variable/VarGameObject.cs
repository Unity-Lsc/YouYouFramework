using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// GameObject变量
    /// </summary>
    public class VarGameObject : Variable<GameObject>
    {

        /// <summary>
        /// 分配一个对象
        /// </summary>
        public static VarGameObject Alloc() {
            VarGameObject var = GameEntry.Pool.DequeueVarObject<VarGameObject>();
            var.Value = null;
            var.Retain();
            return var;
        }
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        public static VarGameObject Alloc(GameObject value) {
            VarGameObject var = Alloc();
            var.Value = value;
            return var;
        }
        /// <summary>
        /// VarGameObject -> GameObject
        /// </summary>
        public static implicit operator GameObject(VarGameObject value) {
            return value.Value;
        }

    }
}
