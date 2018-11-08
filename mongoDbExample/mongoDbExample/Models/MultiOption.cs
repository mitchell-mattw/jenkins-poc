using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongoDbExample.Models
{
    public class MultiOption : Field

    {
        public bool Mutiple { get; set; }
        public List<string> Options { get; set; }
        public string MultiType { get; set; }
    }
}
