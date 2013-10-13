using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace WorkerRole
{
    public class LocalStoragePerformance
    {
        public void ProfileStorageAccess()
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;

            #region Blob

            //Blobs
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference("blobcontainer");
            cloudBlobContainer.CreateIfNotExists();

            ICloudBlob cloudBlob = cloudBlobContainer.GetBlockBlobReference("testblob");

            byte[] data = { 1, 2, 3 };

            using (TimeMeasure.Measure("blob write"))
            {
                cloudBlob.UploadFromByteArray(data, 0, 3);
            }

            #endregion

            #region Queue

            CloudQueueClient queueClient = cloudStorageAccount.CreateCloudQueueClient();

            //Queues
            CloudQueue cloudQueue = queueClient.GetQueueReference("test-queue");
            cloudQueue.CreateIfNotExists();

            using (TimeMeasure.Measure("queue write"))
            {
                cloudQueue.AddMessage(new CloudQueueMessage("testing123"));
            }

            CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();

            #endregion

            #region Table

            //Tables
            CloudTable cloudTable = tableClient.GetTableReference("testtable");
            cloudTable.CreateIfNotExists();

            ITableEntity tableEntity = new DynamicTableEntity
            {
                PartitionKey = "pkey",
                Properties = new Dictionary<string, EntityProperty> { { "name", new EntityProperty("chris") } },
                RowKey = "row1",
            };

            TableOperation operation = TableOperation.InsertOrMerge(tableEntity);

            using (TimeMeasure.Measure("table entity write"))
            {
                cloudTable.Execute(operation);
            };

            #endregion

        }
    }
}
