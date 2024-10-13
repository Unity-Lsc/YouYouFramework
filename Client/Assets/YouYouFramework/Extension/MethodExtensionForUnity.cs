using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Unity的一些扩展方法
    /// </summary>
    public static class MethodExtensionForUnity
    {
        /// <summary>
        /// 添加并获取组件
        /// </summary>
        public static T GetOrAddComponent<T>(this Transform origin) where T : Component {
            if(!origin.TryGetComponent<T>(out var component)) {
                component = origin.gameObject.AddComponent<T>();
            }
            return component;
        }
        /// <summary>
        /// 添加并获取组件
        /// </summary>
        public static T GetOrAddCompponent<T>(this GameObject origin) where T : Component {
            if (!origin.TryGetComponent<T>(out var component)) {
                component = origin.AddComponent<T>();
            }
            return component;
        }

    }
}
