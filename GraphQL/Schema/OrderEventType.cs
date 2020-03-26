using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using Models;

namespace GraphQLAPI
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(e => e.Id);
            Field(e => e.Name);
            Field(e => e.OrderId);
            Field<OrderStatusesEnum>("status", resolve: context => context.Source.Statuses);
            Field(e => e.Timestamp);
        }
    }
}
