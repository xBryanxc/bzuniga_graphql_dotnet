using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OrderCreateInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
    }
}
