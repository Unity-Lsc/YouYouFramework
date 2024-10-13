using System.Threading.Tasks;

namespace YouYou
{
    /// <summary>
    /// 数据表 管理器
    /// </summary>
    public class DataTableManager : ManagerBase
    {
        
        public DTSysAudioDBModel DTSysAudioDBModel { get; private set; }
        public DTSysCodeDBModel DTSysCodeDBModel { get; private set; }
        public DTSysCommonEventIdDBModel DTSysCommonEventIdDBModel { get; private set; }
        public DTSysConfigDBModel DTSysConfigDBModel { get; private set; }
        public DTSysEffectDBModel DTSysEffectDBModel { get; private set; }
        public LocalizationDBModel LocalizationDBModel { get; private set; }
        public DTSysPrefabDBModel DTSysPrefabDBModel { get; private set; }
        public DTSysSceneDBModel DTSysSceneDBModel { get; private set; }
        public DTSysSceneDetailDBModel DTSysSceneDetailDBModel { get; private set; }
        public DTSysStorySoundDBModel DTSysStorySoundDBModel { get; private set; }
        public DTSysUIFormDBModel DTSysUIFormDBModel { get; private set; }

        public DTEquipDBModel DTEquipDBModel { get; private set; }
        public DTShopDBModel DTShopDBModel { get; private set; }
        public DTTaskDBModel DTTaskDBModel { get; private set; }

        public DataTableManager() {
            InitDBModel();
        }

        /// <summary>
        /// 初始化DBModel(数据管理)
        /// </summary>
        private void InitDBModel() {
            //每个表都要实例化一下
            DTSysAudioDBModel = new DTSysAudioDBModel();
            DTSysCodeDBModel = new DTSysCodeDBModel();
            DTSysCommonEventIdDBModel = new DTSysCommonEventIdDBModel();
            DTSysConfigDBModel = new DTSysConfigDBModel();
            DTSysEffectDBModel = new DTSysEffectDBModel();
            LocalizationDBModel = new LocalizationDBModel();
            DTSysPrefabDBModel = new DTSysPrefabDBModel();
            DTSysSceneDBModel = new DTSysSceneDBModel();
            DTSysSceneDetailDBModel = new DTSysSceneDetailDBModel();
            DTSysStorySoundDBModel = new DTSysStorySoundDBModel();
            DTSysUIFormDBModel = new DTSysUIFormDBModel();

            DTEquipDBModel = new DTEquipDBModel();
            DTShopDBModel = new DTShopDBModel();
            DTTaskDBModel = new DTTaskDBModel();
        }

        /// <summary>
        /// 异步加载表格
        /// </summary>
        public void LoadDataTableAsync() {

            Task.Factory.StartNew(LoadDataTable);

        }

        /// <summary>
        /// 加载表格
        /// </summary>
        private void LoadDataTable() {
            //每个表格都要LoadData
            DTSysAudioDBModel.LoadData();
            DTSysCodeDBModel.LoadData();
            DTSysCommonEventIdDBModel.LoadData();
            DTSysConfigDBModel.LoadData();
            DTSysEffectDBModel.LoadData();
            LocalizationDBModel.LoadData();
            DTSysPrefabDBModel.LoadData();
            DTSysSceneDBModel.LoadData();
            DTSysSceneDetailDBModel.LoadData();
            DTSysStorySoundDBModel.LoadData();
            DTSysUIFormDBModel.LoadData();

            DTEquipDBModel.LoadData();
            DTShopDBModel.LoadData();
            DTTaskDBModel.LoadData();

            //load完毕
            GameEntry.Event.CommonEvent.Dispatch(SystemEventId.LoadDataTableComplete);   
        }

        public void Clear() {
            //每个表都要Clear一下
            DTSysAudioDBModel.Clear();
            DTSysCodeDBModel.Clear();
            DTSysCommonEventIdDBModel.Clear();
            DTSysConfigDBModel.Clear();
            DTSysEffectDBModel.Clear();
            LocalizationDBModel.Clear();
            DTSysPrefabDBModel.Clear();
            DTSysSceneDBModel.Clear();
            DTSysSceneDetailDBModel.Clear();
            DTSysStorySoundDBModel.Clear();
            DTSysUIFormDBModel.Clear();

            DTEquipDBModel.Clear();
            DTShopDBModel.Clear();
            DTTaskDBModel.Clear();
        }

    }
}
