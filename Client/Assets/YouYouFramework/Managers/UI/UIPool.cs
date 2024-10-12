using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// UI对象池
    /// </summary>
    public class UIPool
    {
        /// <summary>
        /// 对象池中的UI窗体
        /// </summary>
        private readonly LinkedList<UIFormBase> mUIFormList;

        public UIPool() {
            mUIFormList = new LinkedList<UIFormBase>();
        }

        /// <summary>
        /// 从UI对象池中获取UI
        /// </summary>
        internal UIFormBase Dequeue(int uiFormId) {
            for(LinkedListNode<UIFormBase> curNode = mUIFormList.First; curNode != null; curNode = curNode.Next) {
                if(curNode.Value.UIFormId == uiFormId) {
                    var form = curNode.Value;
                    mUIFormList.Remove(curNode.Value);
                    return form;
                }
            }
            return null;
        }

        /// <summary>
        /// UI回池
        /// </summary>
        internal void Enqueue(UIFormBase formBase) {
            formBase.gameObject.SetActive(false);
            mUIFormList.AddLast(formBase);
        }

        /// <summary>
        /// 检查是否可以释放
        /// </summary>
        internal void CheckClear() {
            for (LinkedListNode<UIFormBase> curNode = mUIFormList.First; curNode != null;) {
                if(!curNode.Value.IsLock && Time.time > (curNode.Value.CloseTime + GameEntry.UI.mUIExpireTime)) {
                    //销毁UI窗体
                    Object.Destroy(curNode.Value.gameObject);

                    LinkedListNode<UIFormBase> next = curNode.Next;
                    mUIFormList.Remove(curNode.Value);
                    curNode = next;
                } else {
                    curNode = curNode.Next;
                }
            }
        }

        internal void CheckByOpenUI() {
            ushort maxCount = GameEntry.UI.UIPoolMaxCount;
            if (mUIFormList.Count <= maxCount) return;
            for (LinkedListNode<UIFormBase> curNode = mUIFormList.First; curNode != null;) {
                //如果池中的数量,小于等于规定的池中最大数量,则不再进行销毁
                if (mUIFormList.Count == maxCount + 1) break;

                if (!curNode.Value.IsLock) {
                    //销毁UI窗体
                    Object.Destroy(curNode.Value.gameObject);

                    LinkedListNode<UIFormBase> next = curNode.Next;
                    mUIFormList.Remove(curNode.Value);
                    curNode = next;
                } else {
                    curNode = curNode.Next;
                }
            }
        }

    }
}
