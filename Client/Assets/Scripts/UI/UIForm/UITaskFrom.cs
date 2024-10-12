using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YouYou;
using static UnityEditor.Timeline.TimelinePlaybackControls;

/// <summary>
/// 任务界面
/// </summary>
public class UITaskFrom : UIFormBase
{

    private Button mBtnClose;
    private Button mBtnReceive;

    private UIScroller mScroller;

    protected override void OnAwake() {
        base.OnAwake();
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
        mScroller.DataCount = 20;
        mScroller.ResetScroller();
    }

    private void OnItemCreate(int index, GameObject obj) {
        obj.gameObject.name = index.ToString();
        obj.transform.Find("txt").GetComponent<Text>().text = "任务:" + index;
    }

    

    protected override void OnOpen(object userData) {
        base.OnOpen(userData);
    }

    protected override void OnClose() {
        base.OnClose();
    }

    protected override void OnBeforeDestory() {
        base.OnBeforeDestory();
    }

}
