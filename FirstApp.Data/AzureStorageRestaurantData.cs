using FirstApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp.Data
{
    class AzureStorageRestaurantData : IRestaurantData
    {

        public List<RestaurantDS> rest;
        readonly DataAccessFacade daf;


        public AzureStorageRestaurantData()
        {
            daf = new TableManager("RestaurantDT");
        }


        public IEnumerable<RestaurantDS> GetRestaurantByName(string name)
        {
            if (name is null)
            {
                rest = daf.RetrieveAll().ToList();
                return rest;
            }
            else
            {
                rest = daf.RetrieveByName().ToList();
                var restslist = from r in rest
                                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) || r.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                orderby r.Name
                                select r;
                return restslist;
            }
        }

        public RestaurantDS GetRestuarantById(long restId)
        {
            return rest.Find(r => r.RowKey == restId.ToString());
        }


        public RestaurantDS Add(RestaurantDS newRest)
        {
            rest.Add(newRest);
            daf.CreateOrUpdate(newRest);
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
            daf.CreateOrUpdate(restSingle);
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
            var restSingle = GetRestuarantById(Id);
            if (restSingle != null)
            {
                daf.Delete(restSingle);
            }
            //After delete, should not return anything except for status
            return null;
        }
    }
}

