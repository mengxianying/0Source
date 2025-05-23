using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public enum StoredProcedureName
    {
        //PBnet_ProductPrice
        P_ProductPrice,

        //ShoppingCart
        sp_InsertShoppingCart,
        sp_SelectShoppingCartByCartGuid,
        sp_UpdateShoppingCart,
        sp_DeleteShoppingCartByCartID,
        sp_DeleteShoppingCartByCartGuid,

        //Orders
        sp_InsertOrders,
        sp_SelectOrdersByOrderID,
        sp_SelectAllOrders,
        sp_SelectOrdersByUserID,
        sp_SelectOrdersByOrderType,
        sp_SelectOrdersBySearch,
        sp_PayForOrders,
        sp_UpdateOrders,
        sp_UpdateOrderStaticTip,

        //Order_OrderStatic
        sp_InsertOrder_OrderStatic,
        sp_UpdateOrder_OrderStatic,
        sp_SelectOrderStaticByOrderID,

        //OrderDetail
        sp_InsertOrderDetail,
        sp_SelectOrderDetailByOrderID,

        //OrderDetail
        sp_InsertOrderDetail_Delegate,
        sp_SelectOrderDetailDelegateByOrderID,


        //OrderStaticTip
        sp_SelectOrderStaticTip,

        //PortType
        sp_SelectAllPortType,

        //PayType
        sp_SelectAllPayType,


        //Favorites
        sp_InsertFavorites,
        sp_SelectFavoritesByUserID,
        sp_DeleteFavoritesByID,

        //HelpDal
        sp_SelectMaxID,

        sp_InsertOrders_Delegates,
        sp_SelectOrdersByOrderID_Delegates,
        sp_UpdateOrders_Delegates,
        sp_PayForOrders_Delegates,
        sp_UpdateOrderStaticTip_Delegates

        
    }
}
