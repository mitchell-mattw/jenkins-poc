using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongoDbExample.Models
{
    public class Field
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public bool Required { get; set; }

        public string Label { get; set; }
       


    }
}
