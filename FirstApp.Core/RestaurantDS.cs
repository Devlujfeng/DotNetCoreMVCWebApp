
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstApp.Core
{
    //public class RestaurantDS: TableEntity
    public class RestaurantDS : TableEntity
    {

        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Location { get; set; }


        public Int64 Id { get; set; }
        public string Type { get; set; }
        public string PK { get; set; }
    }
}
