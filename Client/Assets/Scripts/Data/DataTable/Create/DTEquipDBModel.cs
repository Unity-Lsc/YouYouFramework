//===================================================
//创建时间：2024-10-12 23:26:10
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// DTEquip数据管理
/// </summary>
public partial class DTEquipDBModel : DataTableDBModelBase<DTEquipDBModel, DTEquipEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "DTEquip"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            DTEquipEntity entity = new DTEquipEntity();
            entity.Id = ms.ReadInt();
            entity.Name = ms.ReadUTF8String();
            entity.UsedLevel = ms.ReadInt();
            entity.Quality = ms.ReadInt();
            entity.Star = ms.ReadInt();
            entity.Description = ms.ReadUTF8String();
            entity.Type = ms.ReadInt();
            entity.SellMoney = ms.ReadInt();
            entity.BackAttrOneType = ms.ReadInt();
            entity.BackAttrOneValue = ms.ReadInt();
            entity.BackAttrTwoType = ms.ReadInt();
            entity.BackAttrTwoValue = ms.ReadInt();
            entity.Attack = ms.ReadInt();
            entity.Defense = ms.ReadInt();
            entity.Hit = ms.ReadInt();
            entity.Dodge = ms.ReadInt();
            entity.Cri = ms.ReadInt();
            entity.Res = ms.ReadInt();
            entity.HP = ms.ReadInt();
            entity.MP = ms.ReadInt();
            entity.maxHole = ms.ReadInt();
            entity.embedProps = ms.ReadUTF8String();
            entity.StrengthenItem = ms.ReadInt();
            entity.StrengthenLvMax = ms.ReadInt();
            entity.StrengthenValue = ms.ReadUTF8String();
            entity.StrengthenItemNumber = ms.ReadUTF8String();
            entity.StrengthenGold = ms.ReadUTF8String();
            entity.StrengthenRatio = ms.ReadUTF8String();

            mList.Add(entity);
            mDict[entity.Id] = entity;
        }
    }
}