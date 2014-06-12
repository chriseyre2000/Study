using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAzureDataDelete
{
    public class Class1
    {
        public static void Main()
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "what's up");
            string rowFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, "blah");
            string finalFilter = TableQuery.CombineFilters(partitionFilter, TableOperators.And, rowFilter);

            TableQuery<TestEntity> query = new TableQuery<TestEntity>().Where(finalFilter);

            // THIS THROWS 400 ERROR, does not properly encode partition key
            //var entities = table.ExecuteQuery(query, new TableRequestOptions { RetryPolicy = new NoRetry() });
            //entity = entities.FirstOrDefault();
            
            
            
            // Retrieve storage account from connection string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Create the CloudTable that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("people");

            
            //TableResult result = table.Execute(TableOperation.Retrieve<CustomerEntity>("PK", "RK"));
            //var entity = (CustomerEntity)result.Result;

            // Create a retrieve operation that expects a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<CustomerEntity>("Smith", "Ben");

            // Execute the operation.
            TableResult retrievedResult = table.Execute(retrieveOperation);

            // Assign the result to a CustomerEntity.
            CustomerEntity deleteEntity = (CustomerEntity)retrievedResult.Result;

            // Create the Delete TableOperation.
            if (deleteEntity != null)
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);

                // Execute the operation.
                table.Execute(deleteOperation);

                Console.WriteLine("Entity deleted.");
            }

            else
                Console.WriteLine("Could not retrieve the entity.");
        }
    }
}
