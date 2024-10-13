using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 任务界面
/// </summary>
public class UITaskFrom : UIFormBase
{
    private Text mTxtTaskName;
    private Text mTxtTaskDes;

    private Button mBtnClose;
    private Button mBtnReceive;
    private UIScroller mScroller;

    private List<ServerTaskEntity> mTaskList;

    protected override void OnAwake() {
        base.OnAwake();
        mTxtTaskName = transform.Find("Center/imgRight/txtNameContent").GetComponent<Text>();
        mTxtTaskDes = transform.Find("Center/imgRight/txtDesContent").GetComponent<Text>();
        mBtnClose = transform.Find("Center/btnClose").GetComponent<Button>();
        mBtnReceive = transform.Find("Center/imgRight/btnReceive").GetComponent<Button>();
        mScroller = transform.Find("Center/imgLeft/LeftView").GetComponent<UIScroller>();
    }

    protected override void OnInit(object userData) {
        base.OnInit(userData);
        mBtnClose.onClick.AddListener(() => {
            Close();
        });
        mBtnReceive.onClick.AddListener(() => {
            Debug.Log("接受任务");
            Close();
        });
        mScroller.OnItemCreate = OnItemCreate;
    }

    protected override void OnOpen(object userData) {
        base.OnOpen(userData);
        LoadTaskList();
    }

    private void LoadTaskList() {
        mTaskList = GameEntry.Data.UserDataManager.ServerTaskList;
        mScroller.DataCount = mTaskList.Count;
        mScroller.ResetScroller();
        OnBtnDetailClick(mTaskList[0].Id);
    }

    private void OnItemCreate(int index, GameObject obj) {
        UITaskFormItemView view = obj.GetOrAddCompponent<UITaskFormItemView>();
        view.SetUI(mTaskList[index].Id, OnBtnDetailClick);
    }

    private void OnBtnDetailClick(int taskId) {
        DTTaskEntity entity = GameEntry.DataTable.DataTableManager.DTTaskDBModel.Get(taskId);
        mTxtTaskName.text = GameEntry.Localization.GetString(entity.Name);
        mTxtTaskDes.text = GameEntry.Localization.GetString(entity.Content);
    }

    protected override void OnClose() {
        base.OnClose();
    }

    protected override void OnBeforeDestory() {
        base.OnBeforeDestory();
        mTxtTaskName = null;
        mTxtTaskDes = null;
        mBtnClose = null;
        mBtnReceive = null;
        mScroller = null;

        mTaskList.Clear();
        mTaskList = null;
    }

}
