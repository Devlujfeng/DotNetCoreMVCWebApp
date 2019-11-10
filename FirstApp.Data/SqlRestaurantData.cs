using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FirstAppDbContext db;

        public SqlRestaurantData(FirstAppDbContext db)
        {
            this.db = db;
        }

        public RestaurantDS Add(RestaurantDS newRest)
        {
            db.Add(newRest);
            return newRest;
        }
        
        public int Commit()
        {
            int result = db.SaveChanges();
            return result;
        }

        public RestaurantDS Delete(int Id)
        {
            var restaurant = GetRestuarantById(Id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public string GetCounts()
        {
            return (db.Restaurants.Count() + 1).ToString();
        }

        public IEnumerable<RestaurantDS> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public RestaurantDS GetRestuarantById(long restId)
        {
            return db.Restaurants.Find(restId);
        }

        public RestaurantDS Update(RestaurantDS updatedrds)
        {
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Restaurants] ON");
            var entity = db.Restaurants.Attach(updatedrds);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedrds;
        }
    }
}
