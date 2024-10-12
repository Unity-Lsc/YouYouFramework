using UnityEngine;
using UnityEngine.UI;

namespace YouYou
{
    public class LocalizationText : Text
    {
        [SerializeField]
        [Header("本地化语言的Key")]
        private string mLocalizationKey;

        protected override void Start() {
            base.Start();
            if(GameEntry.Localization != null && !string.IsNullOrEmpty(mLocalizationKey)) {
                text = GameEntry.Localization.GetString(mLocalizationKey);
            }
        }
    }
}
