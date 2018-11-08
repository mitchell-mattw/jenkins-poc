using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace MongoIDM.Models
{
    [CollectionName("users")]
    public class ApplicationUser : MongoIdentityUser
    {



    }
}
