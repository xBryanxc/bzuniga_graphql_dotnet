using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;
using Services;
using Models;
using Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphQLAPI
{
    public class OrdersMutation : ObjectGraphType<object>
    {
        public OrdersMutation(IOrderService orders)
        {
            Name = "Mutation";
            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputType>> { Name = "order" }),
                resolve: context => PersonDelegate.CreatePerson(context, orders)
                //{
                //    var orderInput = context.GetArgument<OrderCreateInput>("order");
                //    var id = Guid.NewGuid().ToString();
                //    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created, orderInput.CustomerId, id);
                //    return orders.CreateAsync(order);
                //}
            );

            //FieldAsync<OrderType>(
            //    "startOrder",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }),
            //    resolve: async context =>
            //    {
            //        var orderId = context.GetArgument<string>("orderId");
            //        return await context.TryAsyncResolve(
            //            async c => await orders.StartAsync(orderId));
            //    }
            //);
            Field<OrderType>(
                "updateOrderStatus",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "id"
                    },
                    new QueryArgument<NonNullGraphType<OrderStatusesEnum>>
                    {
                        Name = "status"
                    }
                    ),
                resolve: context =>
                {
                    var orderID = context.GetArgument<string>("id");
                    var status = context.GetArgument<OrderStatuses>("status");

                    return orders.StartAsync(orderID, status);
                    });
        }
        public class PersonDelegate
        {
            public static Order CreatePerson(ResolveFieldContext<object> context, IOrderService service)
            {
                string output = JsonConvert.SerializeObject(context.Arguments["order"]);
                dynamic orderInput = JObject.Parse(output);
                //IEnumerable<dynamic> phoneNumbers = personInput.phoneNumbers;

                var order = new Order()
                {
                    Name = orderInput.name,
                    Description = orderInput.description,
                    Created = orderInput.created,
                    //Status = orderInput.status ?? OrderStatuses.CREATED,
                    //CustomerId = orderInput.customerid
                };
               
                return service.CreateAsync(order).Result;
            }
        }
    }
}
