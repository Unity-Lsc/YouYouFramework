using System.Collections.Generic;

namespace YouYou
{
    /// <summary>
    /// Localization数据管理
    /// </summary>
    public class LocalizationDBModel : DataTableDBModelBase<LocalizationDBModel, DataTableEntityBase>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName{ get { return "Localization/" + GameEntry.Localization.CurLanguage.ToString(); } }

        public Dictionary<string, string> LocalizationDict = new Dictionary<string, string>();

        /// <summary>
        /// 加载列表
        /// </summary>
        /// <param name="ms"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void LoadList(MMO_MemoryStream ms) {
            int rows = ms.ReadInt();
            int colums = ms.ReadInt();
            for (int i = 0; i < rows; i++) {
                LocalizationDict[ms.ReadUTF8String()] = ms.ReadUTF8String();
            }
        }

        public override void Clear() {
            base.Clear();
            LocalizationDict.Clear();
        }

    }
}
