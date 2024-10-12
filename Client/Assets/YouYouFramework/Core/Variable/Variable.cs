using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 变量泛型基类
    /// </summary>
    public class Variable<T> : VariableBase
    {

        /// <summary>
        /// 当前存储的真实值
        /// </summary>
        public T Value;

        /// <summary>
        /// 变量类型
        /// </summary>
        public override Type Type {
            get {
                return typeof(T);
            }
        }

    }
}
