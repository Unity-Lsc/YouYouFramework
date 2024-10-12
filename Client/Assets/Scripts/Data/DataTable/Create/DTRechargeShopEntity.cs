
//===================================================
//创建时间：2024-10-12 23:26:11
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using YouYou;

/// <summary>
/// DTRechargeShop实体
/// </summary>
public partial class DTRechargeShopEntity : DataTableEntityBase
{
    /// <summary>
    /// 商品类型0=周卡 1=月卡 2=促销礼包 3=普通充值商品
    /// </summary>
    public int Type;

    /// <summary>
    /// 售价
    /// </summary>
    public int Price;

    /// <summary>
    /// 充值商品名称
    /// </summary>
    public string Name;

    /// <summary>
    /// 促销描述
    /// </summary>
    public string SalesDesc;

    /// <summary>
    /// 产品描述(以服务器为准)
    /// </summary>
    public string ProductDesc;

    /// <summary>
    /// 充值后获得虚拟货币
    /// </summary>
    public int Virtual;

    /// <summary>
    /// 充值商品图标
    /// </summary>
    public string Icon;

}
