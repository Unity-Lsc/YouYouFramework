using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Lua组件
    /// </summary>
    public class LuaComponent : YouYouBaseComponent
    {
        private LuaManager mLuaManager;

        private MMO_MemoryStream mLoadDataTableMS;

        protected override void OnAwake() {
            base.OnAwake();
            mLuaManager = new LuaManager();
        }

        protected override void OnStart() {
            base.OnStart();
            mLoadDataTableMS = new MMO_MemoryStream();
            mLuaManager.Init();
        }

        /// <summary>
        /// 加载数据表
        /// </summary>
        public MMO_MemoryStream LoadDataTable(string tableName) {
            //拿到这个表格的buffer
            byte[] buffer = GameEntry.Resource.GetFileBuffer(string.Format("{0}/Download/DataTable/{1}.bytes", GameEntry.Resource.LocalFilePath, tableName));

            mLoadDataTableMS.SetLength(0);
            mLoadDataTableMS.Write(buffer, 0, buffer.Length);
            mLoadDataTableMS.Position = 0;
            return mLoadDataTableMS;
        }

        public override void Shutdown() {
            mLoadDataTableMS.Dispose();
            mLoadDataTableMS.Close();
        }
    }
}
