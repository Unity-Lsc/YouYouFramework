using System;
using System.Collections.Generic;
using XLua;

namespace YouYou
{
    /// <summary>
    /// 通用事件
    /// </summary>
    public class CommonEvent : IDisposable
    {

        [CSharpCallLua]
        public delegate void OnActionHandler(object param);
        public Dictionary<ushort, List<OnActionHandler>> Dict = new Dictionary<ushort, List<OnActionHandler>>();

        /// <summary>
        /// 添加事件监听
        /// </summary>
        public void AddListener(ushort key, OnActionHandler handler) {
            List<OnActionHandler> handlerLst;
            Dict.TryGetValue(key, out handlerLst);
            if(handlerLst == null) {
                handlerLst = new List<OnActionHandler>();
                Dict[key] = handlerLst;
            }
            handlerLst.Add(handler);
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        public void RemoveListener(ushort key, OnActionHandler handler) {
            List<OnActionHandler> handlerLst;
            Dict.TryGetValue(key, out handlerLst);
            if(handlerLst != null) {
                handlerLst.Remove(handler);
                if(handlerLst.Count <= 0) {
                    Dict.Remove(key);
                }
            }
        }

        /// <summary>
        /// 移除某个key下的所有事件监听
        /// </summary>
        public void RemoveListener(ushort key) {
            List<OnActionHandler> handlerLst;
            Dict.TryGetValue(key, out handlerLst);
            if(handlerLst != null) {
                int count = handlerLst.Count;
                for (int i = 0; i < count; i++) {
                    handlerLst.Remove(handlerLst[i]);
                }
                Dict.Remove(key);
            }
        }

        /// <summary>
        /// 事件派发
        /// </summary>
        public void Dispatch(ushort key, object param = null) {
            List<OnActionHandler> handlerLst;
            Dict.TryGetValue(key, out handlerLst);
            if(handlerLst != null) {
                int lstCount = handlerLst.Count;
                for (int i = 0; i < lstCount; i++) {
                    var handler = handlerLst[i];
                    if(handler != null) {
                        handler(param);
                    }
                }
            }
        }

        public void Dispose() {
            Dict.Clear();
        }
    }
}
