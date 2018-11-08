using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using NUnit.Framework;

namespace Tests
{
    public class BsonDocumentTests
    {

        public BsonDocumentTests()
        {

            JsonWriterSettings.Defaults.Indent = true;
        }

        [Test]
        public void EmptyDocument()
        {
            var document = new BsonDocument();
            Console.Write((document));

        }

        [Test]
        public void AddElements()
        {

            var person = new BsonDocument
            {
                {"age", new BsonInt32(54)},
                {"IsAlive", true}
            };
            person.Add("firstName", new BsonString("Bob"));
            Console.Write((person));

        }

        [Test]
        public void AddingArrays()
        {

            var person = new BsonDocument();
            person.Add("address", new BsonArray(new[] {"101 Some Street", "MyTown"}));
            Console.Write((person));

        }

        [Test]
        public void EmbeddedDocument()
        {
            var person = new BsonDocument
            {
                {
                    "contact", new BsonDocument
                    {
                        {"Email", "whatever@email.com"},
                        {"Phone", "1-223-546-876"}
                    }
                }
            };
            Console.Write((person));
        }
    
    [Test]
    public void BsonValueConversions()
    {
        var person = new BsonDocument();
        person.Add("age", 33);

            Console.Write((person["age"].AsInt32 + 10));
            Console.Write((person["age"].IsInt32));
            Console.Write((person["age"].IsString));
        }
    [Test]
    public void ToBson()
    {
        var person = new BsonDocument {{"firstname", "Jim"}};
        Console.Write((person));

        var bson = person.ToBson();
        Console.Write("\n" +  BitConverter.ToString(bson));

        var deserializedPerson = BsonSerializer.Deserialize<BsonDocument>(bson);
        Console.Write("\n" + deserializedPerson);
        }

    }

}
