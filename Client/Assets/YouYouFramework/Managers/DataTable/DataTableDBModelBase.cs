using System.Collections.Generic;

namespace YouYou
{
    /// <summary>
    /// 数据表的管理基类
    /// </summary>
    public abstract class DataTableDBModelBase<T, P> where T: class,new() where P : DataTableEntityBase
    {

        protected List<P> mList;

        protected Dictionary<int, P> mDict;

        public DataTableDBModelBase() {
            mList = new List<P>();
            mDict= new Dictionary<int, P>();
        }

        #region 需要子类实现的属性和方法
        /// <summary>
        /// 数据表名
        /// </summary>
        public abstract string DataTableName { get; }

        /// <summary>
        /// 加载数据列表
        /// </summary>
        protected abstract void LoadList(MMO_MemoryStream ms);

        #endregion

        /// <summary>
        /// 加载数据表数据
        /// </summary>
        public void LoadData() {
            //1.拿到这个表格的buffer
            byte[] buffer = GameEntry.Resource.GetFileBuffer(string.Format("{0}/Download/DataTable/{1}.bytes", GameEntry.Resource.LocalFilePath, DataTableName));

            //2.加载数据
            using(MMO_MemoryStream ms = new MMO_MemoryStream(buffer)) {
                LoadList(ms);
            }

            //3.派发单个表格加载完毕的事件(参数的表格名字)
            GameEntry.Event.CommonEvent.Dispatch(SystemEventId.LoadOneDataTableComplete, DataTableName);

        }

        public List<P> GetList() {
            return mList;
        }

        public P Get(int id) {
            if (mDict.ContainsKey(id)) {
                return mDict[id];
            }
            return null;
        }

        public virtual void Clear() {
            mList.Clear();
            mDict.Clear();
        }

    }
}