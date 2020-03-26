using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace GraphQLAPI
{
    public class OrderCreateInputType : InputObjectGraphType
    {
        public OrderCreateInputType()
        {
            Name = "OrderInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<DateGraphType>>("created");
        }
    }
}
