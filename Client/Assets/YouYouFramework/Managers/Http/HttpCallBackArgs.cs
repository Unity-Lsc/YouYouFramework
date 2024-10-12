using System;

namespace YouYou
{
    /// <summary>
    /// Http请求的回调数据
    /// </summary>
    public class HttpCallBackArgs : EventArgs
    {
        /// <summary>
        /// 是否有错
        /// </summary>
        public bool HasError;

        /// <summary>
        /// 返回值
        /// </summary>
        public string Value;

    }
}
