using System;
using System.Collections.Generic;
using System.Text;
using mongoDbExample.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using NUnit.Framework;

namespace MongoDbTests
{
    public class MongoCRUDTests
    {
        private readonly TestContext _context = new TestContext("mongodb://localhost", "realestate");
        public MongoCRUDTests()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        public class TestContext : MongoDbContext
        {
            public IMongoCollection<Form> Forms
            {
                get { return Database.GetCollection<Form>("forms"); }
            }

            public TestContext(string connectString, string dbName):base (connectString,dbName)
            { }

            
        }

        
        public class FormField
        {
            public string Type { get; set; }
            [BsonElement("FormName")]
            public string Title { get; set; }
            public bool Required { get; set; }
            public string Label { get; set; }

            public Dictionary<string, dynamic> MultiOptions { get; set; }


        }

        public class Form

        {
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId Id { get; set; }
            public string Title { get; set; }   
            public List<FormField> Questions = new List<FormField>();

        }

        public class SubmissionValues
        {
            public int Id { get; set; }
            public int FormId { get; set; }
            public string Title { get; set; }
           // public Dictionary<string, dynamic> FormValues { get; set; }

        }

        [Test]
        public void AddRecordInDatabase()
        {

            var form= new Form
            {
                Title = "Contact3",
                Questions = new List<FormField>()
            };
            var fields = new List<FormField>
            {
                new FormField {Required = false, Title = "FirstName", Label = "First Name", Type = "String"},
                new FormField {Required = true, Title = "LastName", Label = "Last Name", Type = "String"},
                new FormField {Required = true, Title = "Telephone", Label = "Telephone Number", Type = "Int" },
                new FormField {Required = false, Title = "Age", Label = "Age", Type = "Int" },
            };

            form.Questions.AddRange(fields);
            var multiOptions = new Dictionary<string, dynamic>
            {
                {"Multiple", true},
                {"MultiType", "Checkbox"},
                {"Options", new List<string> {"Sales,Finance, Digital, HR, Engineering, Legal"}}
            };

            var field = new FormField
            {
                Label = "Departments",
                Required = false,
                Type = "String",
                MultiOptions = multiOptions
            };
            form.Questions.Add(field);
            _context.Forms.InsertOne(form);
            
        }




    }


}

