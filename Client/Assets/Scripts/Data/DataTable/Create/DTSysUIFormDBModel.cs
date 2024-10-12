//===================================================
//创建时间：2024-10-12 23:26:12
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// DTSysUIForm数据管理
/// </summary>
public partial class DTSysUIFormDBModel : DataTableDBModelBase<DTSysUIFormDBModel, DTSysUIFormEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "DTSysUIForm"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            DTSysUIFormEntity entity = new DTSysUIFormEntity();
            entity.Id = ms.ReadInt();
            entity.Desc = ms.ReadUTF8String();
            entity.Name = ms.ReadUTF8String();
            entity.UIGroupId = (byte)ms.ReadByte();
            entity.IsDisableUILayer = ms.ReadInt();
            entity.IsLock = ms.ReadInt();
            entity.AssetPath_Chinese = ms.ReadUTF8String();
            entity.AssetPath_English = ms.ReadUTF8String();
            entity.CanMulit = ms.ReadBool();
            entity.ShowMode = (byte)ms.ReadByte();
            entity.FreezeMode = (byte)ms.ReadByte();

            mList.Add(entity);
            mDict[entity.Id] = entity;
        }
    }
}