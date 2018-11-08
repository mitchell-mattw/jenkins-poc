using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace mongoDbExample.Models
{
    public class FormSchema
    {
        
        public ObjectId ObjectId { get; set; }
        public string Title { get; set; }

        public List<Field> Questions = new List<Field>(); 
        

    }
}
