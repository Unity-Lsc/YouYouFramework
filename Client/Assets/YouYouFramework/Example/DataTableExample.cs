using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YouYou;
using static UnityEngine.EventSystems.EventTrigger;

public class DataTableExample : MonoBehaviour
{

    void Start()
    {
        
    }

    public void LoadFile() {
        DTEquipDBModel model = new DTEquipDBModel();
        model.LoadData();
        List<DTEquipEntity> lst = model.GetList();
        int len = lst.Count;
        for (int i = 0; i < len; i++) { 
            var entity = lst[i];
            Debug.Log("id:" + entity.Id);
            Debug.Log("Name:" + entity.Name);
            Debug.Log("Money:" + entity.SellMoney);
        }
    }

    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.W)) {
        //    var lst = GameEntry.DataTable.DataTableManager.DTSysUIFormDBModel.GetList();
        //    int len = lst.Count;
        //    for (int i = 0; i < len; i++) {
        //        var entity = lst[i];
        //        Debug.Log("id:" + entity.Id);
        //        Debug.Log("Name:" + entity.Name);
        //        Debug.Log("Path:" + entity.AssetPath_Chinese);
        //    }
        //}
        if (Input.GetKeyUp(KeyCode.W)) {
            string str;
            GameEntry.DataTable.DataTableManager.LocalizationDBModel.LocalizationDict.TryGetValue("Loading.CheckVersion", out str);
            Debug.Log(str);
        }
    }

}
