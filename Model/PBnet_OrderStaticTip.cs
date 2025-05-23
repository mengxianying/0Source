using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_OrderStaticTip 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public enum PBnet_OrderStaticTip
	{
            //等待确认,等待付款 款额不足 已付款 正在配货 已发货 已完成
            等待付款 = 2,
            款额不足 = 3,
            已付款 = 4,
            已开通 = 5,
            已完成 = 6,
            部分开通失败 = 7
	}
}

