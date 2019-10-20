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
        RestaurantDS GetRestuarantById(string restId);
        RestaurantDS Update(RestaurantDS updatedrds);
        RestaurantDS Add(RestaurantDS newRest);
        string GetCounts();
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {

        public List<RestaurantDS> rest;
        readonly TableManager tm;
        

        public InMemoryRestaurantData()
        {
            //rest = new List<RestaurantDS>()
            //{
            //    new RestaurantDS { Id = 1, Name = "Ma La Xiang Guo", Location = "NUS", Type = ShopType.Chinese },
            //    new RestaurantDS { Id = 2, Name = "KFC", Location = "NTU", Type = ShopType.USA },
            //    new RestaurantDS { Id = 3, Name = "Old Chang Kee", Location = "IRAS", Type = ShopType.Singapore }
            //};
            //To call Azure storage
             tm = new TableManager("RestaurantDT");
        }


        public IEnumerable<RestaurantDS> GetRestaurantByName(string name)
        {
            if(name is null)
            {
                rest = tm.RetrieveAll().ToList();
                return rest;
            }
            else
            {
                rest = tm.RetrieveByName().ToList();
                var restslist = from r in rest
                                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) || r.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                orderby r.Name
                                select r;
                return restslist;
            }
        }

        public RestaurantDS GetRestuarantById(string restId)
        {
            return rest.Find(r => r.RowKey == restId.ToString());
        }


        public RestaurantDS Add(RestaurantDS newRest)
        {
            rest.Add(newRest);
            tm.CreateOrUpdate(newRest);
            return newRest;
        }

        public RestaurantDS Update(RestaurantDS updatedrds)
        {
            var restSingle = rest.FirstOrDefault(r => r.RowKey == updatedrds.RowKey);
            if (restSingle != null)
            {
                restSingle.Name = updatedrds.Name;
                restSingle.Location = updatedrds.Location;
                restSingle.Type = updatedrds.Type;
            }
            tm.CreateOrUpdate(restSingle);
            return restSingle;
        }
        public string GetCounts()
        {
            return (rest.Count() + 1).ToString();
        }


        public int Commit()
        {
            return 1;
        }
    }

}
