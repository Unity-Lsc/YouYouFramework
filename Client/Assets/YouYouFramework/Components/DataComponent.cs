
namespace YouYou
{
    /// <summary>
    /// 数据组件
    /// </summary>
    public class DataComponent : YouYouBaseComponent
    {
        /// <summary>
        /// 临时缓存数据
        /// </summary>
        public CacheDataManager CacheDataManager { get; private set; }
        /// <summary>
        /// 系统相关数据
        /// </summary>
        public SystemDataManager SystemDataManager { get; private set; }
        /// <summary>
        /// 用户相关数据
        /// </summary>
        public UserDataManager UserDataManager { get; private set; }
        /// <summary>
        /// 关卡地图数据
        /// </summary>
        public PVEMapDataManager PVEMapDataManager { get; private set; }

        protected override void OnAwake() {
            base.OnAwake();
            CacheDataManager = new CacheDataManager();
            SystemDataManager = new SystemDataManager();
            UserDataManager = new UserDataManager();
            PVEMapDataManager = new PVEMapDataManager();
        }


        public override void Shutdown() {
            CacheDataManager.Dispose();
            SystemDataManager.Dispose();
            UserDataManager.Dispose();
            PVEMapDataManager.Dispose();
        }
    }
}
