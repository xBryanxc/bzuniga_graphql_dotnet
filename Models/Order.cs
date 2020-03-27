using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Order
    {
        public Order(/*string name, string description, DateTime created, int customerId, string Id*/)
        {
        //    Name = name;
        //    Description = description;
        //    Created = created;
        //    CustomerId = customerId;
        this.Id = Id;
        Status = OrderStatuses.CREATED;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }
        
        public int CustomerId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public OrderStatuses Status { get; set; }
    }

    [Flags]
    public enum OrderStatuses
    {
        CREATED = 2,
        PROCESSING = 4,
        COMPLETED = 8,
        CANCELLED = 16,
        CLOSED = 32
    }
}
