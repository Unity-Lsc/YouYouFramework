using System;
using System.Collections.Generic;

/// <summary>
/// 用户数据
/// </summary>
public class UserDataManager : IDisposable
{
    /// <summary>
    /// 服务器端返回的任务列表
    /// </summary>
    public List<ServerTaskEntity> ServerTaskList {
        get; private set;
    }

    public UserDataManager() {
        ServerTaskList = new List<ServerTaskEntity>();
    }

    public void ReceiveTask() {
        ServerTaskList.Add(new ServerTaskEntity() { Id = 1001, Status = 0 });
    }

    /// <summary>
    /// 清空数据(退出登录时清空)
    /// </summary>
    public void Clear() {
        ServerTaskList.Clear();
    }

    public void Dispose() {
        ServerTaskList.Clear();
    }

}
