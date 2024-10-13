using System;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Lua组件类型
    /// </summary>
    public enum LuaCompType {
        GameObject = 0,
        Transform,
        Button,
        Image,
        LocalizationImage,
        Text,
        LocalizationText,
        RawImage,
        InputField,
        Scrollbar,
        ScrollRect,
        UIMultiScroller,
        UIScroller,
    }

    /// <summary>
    /// Lua组件
    /// </summary>
    [Serializable]
    public class LuaComp
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 类型
        /// </summary>
        public LuaCompType Type;

        /// <summary>
        /// Transform
        /// </summary>
        public Transform Tran;

        

    }
}
