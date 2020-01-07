using Microsoft.Azure.Cosmos.Table;
using System;

namespace FirstApp.Data
{
    internal class OrderEntity : TableEntity
    {
        private string v1;
        private string v2;

        public OrderEntity(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public string OrderNumber { get; internal set; }
        public DateTime OrderDate { get; internal set; }
        public DateTime ShippedDate { get; internal set; }
        public string Status { get; internal set; }
    }
}