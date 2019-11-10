using FirstApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Data
{
    public class DataAccessFacade
    {

        public virtual IEnumerable<RestaurantDS> RetrieveAll() => null;
        public virtual void CreateOrUpdate(RestaurantDS ds) { }
        public virtual IEnumerable<RestaurantDS> RetrieveByName() => null;
        public virtual void Delete(RestaurantDS ds) { }
    }
}
