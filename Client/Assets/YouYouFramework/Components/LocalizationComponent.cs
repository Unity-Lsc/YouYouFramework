using UnityEngine;

namespace YouYou
{

    public enum LocalizationLanguage {
        Chinese = 0,
        English = 1
    }

    /// <summary>
    /// 本地化(多语言)组件
    /// </summary>
    public class LocalizationComponent : YouYouBaseComponent
    {
        [SerializeField]
        private LocalizationLanguage m_CurLanguage;
        /// <summary>
        /// 当前语言(需要和本地化表格中的字段保持一致)
        /// </summary>
        public LocalizationLanguage CurLanguage {
            get { return m_CurLanguage; }
        }

        private LocalizationManager mLocalizationManager;

        protected override void OnAwake() {
            base.OnAwake();
            mLocalizationManager = new LocalizationManager();
#if !UNITY_EDITOR
            Init();
#endif
        }

        private void Init() {
            switch (Application.systemLanguage) {
                default:
                case SystemLanguage.Chinese:
                case SystemLanguage.ChineseSimplified:
                case SystemLanguage.ChineseTraditional:
                    m_CurLanguage = LocalizationLanguage.Chinese;
                    break;
                case SystemLanguage.English:
                    m_CurLanguage = LocalizationLanguage.English;
                    break;
            }
        }

        /// <summary>
        /// 获取本地化文本内容
        /// </summary>
        public string GetString(string key, params object[] args) {
            return mLocalizationManager.GetString(key, args);
        }
        /// <summary>
        /// 获取本地化文本内容
        /// </summary>
        public string GetString(string key) {
            return mLocalizationManager.GetString(key);
        }

        public override void Shutdown() {
            
        }
    }
}
