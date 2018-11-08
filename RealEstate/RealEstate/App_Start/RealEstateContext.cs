using MongoDB.Driver;
using RealEstate.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.App_Start
{
    public class RealEstateContext
    {
        public IMongoDatabase Database;
        public RealEstateContext()
        {

            var mongoClient = new MongoClient(Settings.Default.mongodb);
            Database = mongoClient.GetDatabase(Settings.Default.realestatedbname);

        }
    }
}