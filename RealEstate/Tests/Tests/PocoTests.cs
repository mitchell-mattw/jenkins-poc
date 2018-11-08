using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using NUnit.Framework;

namespace Tests
{
    public class PocoTests
    {
        public PocoTests()
        {

            JsonWriterSettings.Defaults.Indent = true;
        }

        public class Person
        {
            public string FullName { get; set; }
            public int Age { get; set; }

            public List<string> Address = new List<string>();
            public Contact Contact = new Contact();
        }
        public class Contact
        {
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
           
        }

        [Test]
        public void Automatic()
        {
            var person = new Person
            {
                Age = 45,
                FullName = "Jim Smith"
            };
            person.Address.Add("101 some thing");
            person.Address.Add("Test Town");
            person.Contact.Email = "info@someemail.com";
            person.Contact.PhoneNumber = "0115 74644";

            Console.WriteLine(person.ToJson());
        }
    }
}