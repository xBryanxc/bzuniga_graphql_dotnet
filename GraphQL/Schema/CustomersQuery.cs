using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using Services;

namespace GraphQLAPI.Schema
{
    public class CustomersQuery : ObjectGraphType<object>
    {
        public CustomersQuery(ICustomerService customers)
        {
            Name = "Query";
            Field<ListGraphType<CustomerType>>("customers", resolve: context => customers.GetCustomersAsync());
        }
    }
}
