using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;

namespace GraphQLAPI.Schema
{
    public class CustomersSchema : GraphQL.Types.Schema
    {
        public CustomersSchema(CustomersQuery query, IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}
