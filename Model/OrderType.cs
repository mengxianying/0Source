using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public enum OrderType
    {
        //0所有订单，1今日订单，2未确认，3未付款，4未发货，5已付款，6已发货，7已取消
        All = 0,
        Today = 1,
        NoConfirm = 2,
        NoPayed = 3,
        NoPorted = 4,
        HasPayed = 5,
        HasPorted = 6,
        HasCancel = 7
    }
}
