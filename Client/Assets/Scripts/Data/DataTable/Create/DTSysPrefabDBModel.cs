//===================================================
//创建时间：2024-10-12 23:26:11
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// DTSysPrefab数据管理
/// </summary>
public partial class DTSysPrefabDBModel : DataTableDBModelBase<DTSysPrefabDBModel, DTSysPrefabEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "DTSysPrefab"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            DTSysPrefabEntity entity = new DTSysPrefabEntity();
            entity.Id = ms.ReadInt();
            entity.Desc = ms.ReadUTF8String();
            entity.Name = ms.ReadUTF8String();
            entity.AssetCategory = ms.ReadInt();
            entity.AssetPath = ms.ReadUTF8String();
            entity.PoolId = (byte)ms.ReadByte();
            entity.CullDespawned = (byte)ms.ReadByte();
            entity.CullAbove = ms.ReadInt();
            entity.CullDelay = ms.ReadInt();
            entity.CullMaxPerPass = ms.ReadInt();

            mList.Add(entity);
            mDict[entity.Id] = entity;
        }
    }
}