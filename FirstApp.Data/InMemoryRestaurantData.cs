using FirstApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp.Data
{
    public class InMemoryRestaurantData : DataAccessFacade, IRestaurantData
    {

        public List<RestaurantDS> rest;
        public InMemoryRestaurantData()
        {
            //InMemoryData
            rest = new List<RestaurantDS>()
            {
                new RestaurantDS { Id = 1, Name = "Ma La Xiang Guo", Location = "NUS", Type = "Chinese"  },
                new RestaurantDS { Id = 2, Name = "KFC", Location = "NTU", Type = "USA" },
                new RestaurantDS { Id = 3, Name = "Old Chang Kee", Location = "IRAS", Type = "Singapore" }
            };
        }


        public IEnumerable<RestaurantDS> GetRestaurantByName(string name)
        {
            if (name is null)
            {
                return rest;
            }
            else
            {
                var restslist = from r in rest
                                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) || r.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                orderby r.Name
                                select r;
                return restslist;
            }
        }

        public RestaurantDS GetRestuarantById(long restId)
        {
            return rest.Find(r => r.Id == Convert.ToInt64(restId));
        }


        public RestaurantDS Add(RestaurantDS newRest)
        {
            rest.Add(newRest);
            return newRest;
        }

        public RestaurantDS Update(RestaurantDS updatedrds)
        {
            var restSingle = rest.FirstOrDefault(r => r.Id == updatedrds.Id);
            if (restSingle != null)
            {
                restSingle.Name = updatedrds.Name;
                restSingle.Location = updatedrds.Location;
                restSingle.Type = updatedrds.Type;
            }
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

        public RestaurantDS Delete(int Id)
        {
            var restSingle = rest.Find(r => r.Id == Id);
            if (restSingle != null)
            {
                rest.Remove(restSingle);
            }
            return null;
        }
    }
}
