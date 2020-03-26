using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using Models;

namespace GraphQLAPI
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);
            Field(c => c.Name);
        }
    }
}
