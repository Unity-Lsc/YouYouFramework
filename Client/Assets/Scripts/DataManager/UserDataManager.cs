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

        //测试代码
        ServerTaskList.Add(new ServerTaskEntity() { Id = 1001, Status = 0 });
        ServerTaskList.Add(new ServerTaskEntity() { Id = 1002, Status = 0 });
        ServerTaskList.Add(new ServerTaskEntity() { Id = 1003, Status = 0 });
        ServerTaskList.Add(new ServerTaskEntity() { Id = 1004, Status = 0 });
    }

    public void AddList() {
        ServerTaskList.Add(new ServerTaskEntity() { Id = 1005, Status = 0 });
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
