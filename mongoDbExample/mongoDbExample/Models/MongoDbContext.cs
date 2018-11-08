using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using mongoDbExample.Properties;



namespace mongoDbExample.Models
{
    public class MongoDbContext
    {

        public IMongoDatabase Database;
        private string connectString;
        private string dbName;

        
        public MongoDbContext(string connectString, string dbName)
        {
            this.connectString = connectString;
            this.dbName = dbName;

            IMongoClient client = new MongoClient(this.connectString);
            Database=client.GetDatabase(this.dbName);

        }
    }
}
