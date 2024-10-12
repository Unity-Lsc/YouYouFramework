using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// UI层级管理
    /// </summary>
    public class UILayer
    {

        private Dictionary<byte, ushort> mUILayerDict;

        public UILayer() {
            mUILayerDict = new Dictionary<byte, ushort>();
        }

        /// <summary>
        /// 初始化基础排序
        /// </summary>
        internal void Init(UIGroup[] groups) {
            int len = groups.Length;
            for (int i = 0; i < len; i++) {
                UIGroup group = groups[i];
                mUILayerDict[group.Id] = group.BaseOrder;
            }
        }

        /// <summary>
        /// 设置层级排序
        /// </summary>
        /// <param name="formBase">要排序的UI窗体</param>
        /// <param name="isRise">层级是升高还是降低</param>
        internal void SetSortingOrder(UIFormBase formBase, bool isRise = true) {
            if (isRise) {
                mUILayerDict[formBase.GroupId] += 10;
            } else {
                mUILayerDict[formBase.GroupId] -= 10;
            }
            formBase.CurCanvas.sortingOrder = mUILayerDict[formBase.GroupId];
        }

    }
}
