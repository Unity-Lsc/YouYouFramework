//===================================================
//创建时间：2024-10-12 23:26:11
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// DTShop数据管理
/// </summary>
public partial class DTShopDBModel : DataTableDBModelBase<DTShopDBModel, DTShopEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "DTShop"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            DTShopEntity entity = new DTShopEntity();
            entity.Id = ms.ReadInt();
            entity.ShopCategoryId = ms.ReadInt();
            entity.GoodsType = ms.ReadInt();
            entity.GoodsId = ms.ReadInt();
            entity.OldPrice = ms.ReadInt();
            entity.Price = ms.ReadInt();
            entity.SellStatus = ms.ReadInt();

            mList.Add(entity);
            mDict[entity.Id] = entity;
        }
    }
}