using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;

namespace GraphQLAPI
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(OrdersQuery query, OrdersMutation mutation, OrdersSubscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}
