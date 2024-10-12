using UnityEngine;
using UnityEngine.UI;

namespace YouYou
{
    public class LocalizationImage : Image
    {

        [SerializeField]
        [Header("本地化语言的Key")]
        private string mLocalizationKey;

        protected override void Start() {
            base.Start();
            if (GameEntry.Localization != null && !string.IsNullOrEmpty(mLocalizationKey)) {
                string path = GameUtil.GetUIResPath(GameEntry.Localization.GetString(mLocalizationKey));
                Texture2D tex = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>(path);
                Sprite sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                sprite = sp;
                SetNativeSize();
            }
        }

    }
}
