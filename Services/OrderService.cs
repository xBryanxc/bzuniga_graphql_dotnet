using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Services;

namespace Orders
{
    public class OrderService : IOrderService
    {
        private IOrderEventService _events;

        public OrderService(IOrderEventService eventsService)
        {
            _events = eventsService;
        }

        public Task<Order> CreateAsync(Order order)
        {
            using (var context = new DB_context())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }


            //event/Subscripcions
            var orderEvent = new OrderEvent()
            {
                Id = order.Id,
                OrderId = order.Id,
                Name = order.Name,
                Statuses = order.Status,
                Timestamp = order.Created
            };
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> GetOrderByIdAsync(string id)
        {
            Order order = null;
            using (var context = new DB_context())
            {
                order = context.Orders.SingleOrDefault(o => o.Id == id);
            }
            return Task.FromResult(order);
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            List<Order> orders = new List<Order>();
            using (var context = new DB_context())
            {
                orders = context.Orders.OrderBy(o => o.Status).ToList();
            }
            return Task.FromResult(orders.AsEnumerable());
        }

        public Task<Order> StartAsync(string orderId, OrderStatuses status)
        {
            //var order = GetById(orderId);
            ////order.Start();
            //var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.PROCESSING, DateTime.Now);
            //_events.AddEvent(orderEvent);
            //return Task.FromResult(order);
            Order order = null;
            using(var context = new DB_context())
            {
                order = context.Orders.SingleOrDefault(p => p.Id == orderId);

                order.Status = status;
                context.SaveChanges();
            }
            return Task.FromResult(order);
        }
    }

    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> StartAsync(string orderId, OrderStatuses status);
    }
}