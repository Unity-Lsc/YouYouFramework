//===================================================
//创建时间：2024-10-12 23:26:12
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// DTSysScene数据管理
/// </summary>
public partial class DTSysSceneDBModel : DataTableDBModelBase<DTSysSceneDBModel, DTSysSceneEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "DTSysScene"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            DTSysSceneEntity entity = new DTSysSceneEntity();
            entity.Id = ms.ReadInt();
            entity.Desc = ms.ReadUTF8String();
            entity.Name = ms.ReadUTF8String();
            entity.SceneName = ms.ReadUTF8String();
            entity.BGMId = ms.ReadInt();
            entity.SceneType = ms.ReadInt();
            entity.PlayerBornPos_1 = ms.ReadFloat();
            entity.PlayerBornPos_2 = ms.ReadFloat();
            entity.PlayerBornPos_3 = ms.ReadFloat();

            mList.Add(entity);
            mDict[entity.Id] = entity;
        }
    }
}