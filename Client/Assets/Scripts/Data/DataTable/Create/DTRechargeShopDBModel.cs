//===================================================
//创建时间：2024-10-14 22:01:39
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// DTRechargeShop数据管理
/// </summary>
public partial class DTRechargeShopDBModel : DataTableDBModelBase<DTRechargeShopDBModel, DTRechargeShopEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "DTRechargeShop"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            DTRechargeShopEntity entity = new DTRechargeShopEntity();
            entity.Id = ms.ReadInt();
            entity.Type = ms.ReadInt();
            entity.Price = ms.ReadInt();
            entity.Name = ms.ReadUTF8String();
            entity.SalesDesc = ms.ReadUTF8String();
            entity.ProductDesc = ms.ReadUTF8String();
            entity.Virtual = ms.ReadInt();
            entity.Icon = ms.ReadUTF8String();

            mList.Add(entity);
            mDict[entity.Id] = entity;
        }
    }
}