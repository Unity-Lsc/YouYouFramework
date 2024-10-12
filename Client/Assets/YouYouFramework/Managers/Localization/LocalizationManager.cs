
namespace YouYou
{
    /// <summary>
    /// 本地化(多语言) 管理器
    /// </summary>
    public class LocalizationManager : ManagerBase
    {
        /// <summary>
        /// 获取本地化文本内容
        /// </summary>
        public string GetString(string key, params object[] args) {
            string value = string.Empty;
            if (GameEntry.DataTable.DataTableManager.LocalizationDBModel.LocalizationDict.TryGetValue(key, out value)) {
                return string.Format(value, args);
            }
            return value;
        }
        /// <summary>
        /// 获取本地化文本内容
        /// </summary>
        public string GetString(string key) {
            string value = string.Empty;
            if (GameEntry.DataTable.DataTableManager.LocalizationDBModel.LocalizationDict.TryGetValue(key, out value)) {
                return value;
            }
            return value;
        }

    }
}
