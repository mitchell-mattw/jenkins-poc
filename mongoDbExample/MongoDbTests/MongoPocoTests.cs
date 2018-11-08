using System;
using System.Collections.Generic;
using mongoDbExample.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace MongoDbTests
{
    public class MongoPocoTests
    {
       
        public MongoPocoTests()
        {

            JsonWriterSettings.Defaults.Indent = true;

        }

        [Test]
        public void FieldInheritence()
        {

            FormSchema content = new FormSchema
            {
                Title = "Contact",
                Questions = new List<Field>()
            };
            var fields = new List<Field>
            {
                new Field {Required = false, Title = "FirstName", Label = "First Name", Type = "String"},
                new Field {Required = true, Title = "LastName", Label = "Last Name", Type = "String"},
                new Field {Required = true, Title = "Telephone", Label = "Telephone Number", Type = "Int" },
                new Field {Required = false, Title = "Age", Label = "Age", Type = "Int" },
            };
            content.Questions.AddRange(fields);
            var multiField = new MultiOption
            {
                Mutiple = true,
                Options = new List<string> { "Sales,Finance, Digital, HR, Engineering, Legal" },
                Label = "Departments",
                Required = false,
                Type = "String",
                MultiType = "Checkbox"
            };

            content.Questions.Add(multiField);
            Console.WriteLine(content.ToJson());
        }



        public class FlatField
        {
            public string Type { get; set; }
            [BsonElement("FormName")]
            public string Title { get; set; }
            public bool Required { get; set; }
            public string Label { get; set; }

            public Dictionary<string, dynamic> MultiOptions { get; set; }

            public dynamic Answer { get; set; }
        }


        public class FormFlatSchema
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId Id { get; set; }
            public string Title { get; set; }

            public List<FlatField> Questions = new List<FlatField>();

           


        }

        [Test]
        public void Dynamictest()
        {

            FormFlatSchema content = new FormFlatSchema
            {
                Title = "Contact2",
                Questions = new List<FlatField>()
            };

            Console.WriteLine(content.ToJson());

        }



        [Test]
        public void FieldWithDictionary()
        {

            FormFlatSchema content = new FormFlatSchema
            {
                Title = "Contact2",
                Questions = new List<FlatField>(),
                
            };
            var fields = new List<FlatField>
            {
                new FlatField {Required = false, Title = "FirstName", Label = "First Name", Type = "String", Answer = 123},
                new FlatField {Required = true, Title = "LastName", Label = "Last Name", Type = "String", Answer = true},
                new FlatField {Required = true, Title = "Telephone", Label = "Telephone Number", Type = "Int", Answer = "Sinden"},
                new FlatField {Required = false, Title = "Age", Label = "Age", Type = "Int", Answer = new []{"A", "B", "C"}},
            };

            content.Questions.AddRange(fields);
            var multiOptions = new Dictionary<string, dynamic>
            {
                {"Multiple", true},
                {"MultiType", "Checkbox"},
                {"Options", new List<string> {"Sales,Finance, Digital, HR, Engineering, Legal"}}
            };
            
            var field = new FlatField
            {
                Label = "Departments",
                Required = false,
                Type = "String",
                MultiOptions = multiOptions
            };
            content.Questions.Add(field);
            Console.WriteLine(content.ToJson());
        }


    [Test]
    public void EmptyDocument()
    {
        var document = new BsonDocument();
        Console.Write((document));

    }

}
}
