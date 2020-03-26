using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OrderEvent
    {
        //public OrderEvent(string orderId, string name, OrderStatuses statuses, DateTime timestamp)
        //{
        //    OrderId = orderId;
        //    Name = name;
        //    Statuses = statuses;
        //    Timestamp = timestamp;
        //    Id = Guid.NewGuid().ToString();
        //}

        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public OrderStatuses Statuses { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
