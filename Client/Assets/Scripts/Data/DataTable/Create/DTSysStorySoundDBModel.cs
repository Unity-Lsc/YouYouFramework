//===================================================
//创建时间：2024-10-12 23:26:12
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// DTSysStorySound数据管理
/// </summary>
public partial class DTSysStorySoundDBModel : DataTableDBModelBase<DTSysStorySoundDBModel, DTSysStorySoundEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "DTSysStorySound"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            DTSysStorySoundEntity entity = new DTSysStorySoundEntity();
            entity.Id = ms.ReadInt();
            entity.Desc = ms.ReadUTF8String();
            entity.AssetPath_CN = ms.ReadUTF8String();
            entity.AssetPath_EN = ms.ReadUTF8String();

            mList.Add(entity);
            mDict[entity.Id] = entity;
        }
    }
}