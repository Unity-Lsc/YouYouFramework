using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class UIExample : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W)) {
            //GameEntry.UI.OpenUIForm(UIFormId.UITask);
            GameEntry.UI.OpenUIForm(UIFormId.UITask);
            //GameEntry.UI.OpenUIForm<UILoadingForm>(UIFormId.UILoading);
            //Object prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Download/UI/UIPrefab/Loading/UILoading.prefab");
            //Debug.Log(prefab);
            //GameObject obj = Object.Instantiate(prefab) as GameObject;
            //RectTransform rect = obj.GetComponent<RectTransform>();
            //rect.SetParent(GameEntry.UI.GetUIGroup(3).Group);
            //rect.localPosition = Vector3.zero;
            //rect.localScale = Vector3.one;
            //rect.offsetMin = Vector2.zero;
            //rect.offsetMax = Vector2.zero;
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            GameEntry.Data.UserDataManager.AddList();
        }
    }

}
