using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.SQLServerDAL;
using System.Data;

namespace Pbzx.BLL
{
    public class PBnet_FavoritesBll
    {
        private static readonly Pbzx.SQLServerDAL.PBnet_FavoritesDal Dal = new Pbzx.SQLServerDAL.PBnet_FavoritesDal();
        public int InsertFavorites(Pbzx.Model.PBnet_Favorites favorites)
        {
            return Dal.InsertFavorites(favorites);
        }

        public DataSet SelectFavoritesByUserID(int userID)
        {
            return Dal.SelectFavoritesByUserID(userID);
        }

        public int DeleteFavoritesByID(string favoritesID)
        {
            int tempID = 0;
            if (!int.TryParse(favoritesID, out tempID))
                return -1;

            return Dal.DeleteFavoritesByID(tempID);
        }

        public int SelectMaxID()
        {
            return new HelpDal().SelectMaxID("Favorites", "FavoritesID");
        }
    }
}
