using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Http组件
    /// </summary>
    public class HttpComponent : YouYouBaseComponent
    {

        private HttpManager mHttpManager;

        [SerializeField]
        [Header("正式帐号服务器URL")]
        private string mWebAccountUrl;

        [SerializeField]
        [Header("测试帐号服务器URL")]
        private string mTestWebAccountUrl;

        [SerializeField]
        [Header("是否是测试环境")]
        private bool mIsTest;

        /// <summary>
        /// 帐号服务器URL
        /// </summary>
        public string RealWebAccountUrl{
            get { return mIsTest ? mTestWebAccountUrl : mWebAccountUrl; }
        }

        protected override void OnAwake() {
            base.OnAwake();
            mHttpManager = new HttpManager();
        }

        /// <summary>
        /// 发送Http数据
        /// </summary>
        public void SendData(string url, HttpSendDataCallBack callback, bool isPost = false, Dictionary<string, object> dict = null) {
            mHttpManager.SendData(url, callback, isPost, dict);
        }

        public override void Shutdown() {
            
        }
    }
}
