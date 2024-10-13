using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

public class UITaskFormItemView : MonoBehaviour
{

    private Button mBtnDetail;
    private Text mTxtName;

    private Action<int> mOnClick;
    private int mTaskId;

    private void Awake() {
        mBtnDetail = transform.Find("btnDetail").GetComponent<Button>();
        mTxtName = mBtnDetail.transform.Find("txtName").GetComponent<Text>();

        mBtnDetail.onClick.AddListener(() => {
            mOnClick?.Invoke(mTaskId);
        });
    }

    public void SetUI(int taskId, Action<int> onClick = null) {
        mTaskId = taskId;
        mOnClick = onClick;
        mTxtName.text = GameEntry.Localization.GetString(GameEntry.DataTable.DataTableManager.DTTaskDBModel.Get(taskId).Name);
    }

}
