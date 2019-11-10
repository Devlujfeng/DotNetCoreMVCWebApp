using FirstApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<RestaurantDS> GetRestaurantByName(string name);
        RestaurantDS GetRestuarantById(long restId);
        RestaurantDS Update(RestaurantDS updatedrds);
        RestaurantDS Add(RestaurantDS newRest);

        RestaurantDS Delete(int Id);
        string GetCounts();
        int Commit();
    }



}
