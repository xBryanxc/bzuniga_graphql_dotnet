using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using System.Linq;
using Orders;

namespace GraphQLAPI
{
    public class OrdersQuery : ObjectGraphType<object>
    {
        public OrdersQuery(IOrderService orders)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>("orders",resolve: context => orders.GetOrdersAsync());
        }
    }
}
