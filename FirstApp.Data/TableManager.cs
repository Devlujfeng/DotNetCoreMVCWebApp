using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Core;

using Microsoft.Azure.Cosmos.Table;

namespace FirstApp.Data
{
    public class TableManager
    {
        // private property  
        private CloudTable table;

        // Constructor   
        public TableManager(string _CloudTableName)
        {
            if (string.IsNullOrEmpty(_CloudTableName))
            {
                throw new ArgumentNullException("Table", "Table Name can't be empty");
            }
            try
            {
                
                string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=lujfengstorage;AccountKey=FkNOkzPxWCm6wP0XxTNZIgX4TrmMcbotWm5F/0a8jZZs2qAQTaixAi82DVsoJt5+ugfvwgcn5mMHTshsFyQPqQ==;EndpointSuffix=core.windows.net";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                //this only get the table reference
                table = tableClient.GetTableReference(_CloudTableName);
                table.CreateIfNotExists();
            }
            catch (StorageException StorageExceptionObj)
            {
                throw StorageExceptionObj;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        public IEnumerable<RestaurantDS> RetrieveByName()
        {
            var query = new TableQuery<RestaurantDS>();
            var results = table.ExecuteQuery(query);
            return results;
        }

        public IEnumerable<RestaurantDS> RetrieveAll()
        {
            //perform query to get the values from azure storage
            var query = new TableQuery<RestaurantDS>();
            var results = table.ExecuteQuery(query);



            // Define the additional columns we want, and pass them into Retrieve

            //var retrieve = TableOperation.Retrieve<MyEntity>(partitionKey, rowKey, columns);

            //TableOperation tq = TableOperation.Retrieve<RestaurantDS>("aa", "b", new list);
            //TableResult data = TableEnt


            //var columns = new List<string>() { "Name", "Location" };
            //TableOperation retrieve = TableOperation.Retrieve<RestaurantDS>("CN", "6");
            //TableResult tr = table.Execute(retrieve);
            //TableBatchOperation tbo = new TableBatchOperation();

            return results;
        }

        //Insert multiple sets of user information to Azure table
        public void InsertOrders(CloudStorageAccount storageAccount)
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("orders");
            TableBatchOperation batchOperation = new TableBatchOperation();

            OrderEntity newOrder1 = new OrderEntity("Smith", "20150410")
            {
                OrderNumber = "1",
                OrderDate = Convert.ToDateTime("20150410"),
                ShippedDate = Convert.ToDateTime("20150411"),
                Status = "shipped"
            };

            OrderEntity newOrder2 = new OrderEntity("Jones", "20150413");
            newOrder2.OrderNumber = "2";
            newOrder2.OrderDate = Convert.ToDateTime("20150413");
            newOrder2.ShippedDate = Convert.ToDateTime("19000101");
            newOrder2.Status = "pending";

            batchOperation.Insert(newOrder1);
            batchOperation.Insert(newOrder2);

            table.ExecuteBatch(batchOperation);
        }


        public void CreateOrUpdate(RestaurantDS ds)
        {
            List<RestaurantDS> dslist = new List<RestaurantDS>();
            dslist.Add(ds);
            var operation = TableOperation.InsertOrReplace(ds);
            table.Execute(operation);
        }

        public void Delete(RestaurantDS ds)
        {
            var operation = TableOperation.Delete(ds);
            table.Execute(operation);
        }




        //public void InsertEntity<T>(T entity, bool forInsert = true) where T : TableEntity, new()
        //{
        //    try
        //    {
        //        if (forInsert)
        //        {
        //            var insertOperation = TableOperation.Insert(entity);
        //            table.Execute(insertOperation);
        //        }
        //        else
        //        {
        //            var insertOrMergeOperation = TableOperation.InsertOrReplace(entity);
        //            table.Execute(insertOrMergeOperation);
        //        }
        //    }
        //    catch (Exception ExceptionObj)
        //    {
        //        throw ExceptionObj;
        //    }
        //}
        //public List<T> RetrieveEntity<T>(string Query = null) where T : TableEntity, new()
        //{
        //    try
        //    {
        //        // Create the Table Query Object for Azure Table Storage  
        //        TableQuery<T> DataTableQuery = new TableQuery<T>();
        //        if (!String.IsNullOrEmpty(Query))
        //        {
        //            DataTableQuery = new TableQuery<T>().Where(Query);
        //        }
        //        IEnumerable<T> IDataList = table.ExecuteQuery(DataTableQuery);
        //        List<T> DataList = new List<T>();
        //        foreach (var singleData in IDataList)
        //            DataList.Add(singleData);
        //        return DataList;
        //    }
        //    catch (Exception ExceptionObj)
        //    {
        //        throw ExceptionObj;
        //    }
        //}
    }
}
