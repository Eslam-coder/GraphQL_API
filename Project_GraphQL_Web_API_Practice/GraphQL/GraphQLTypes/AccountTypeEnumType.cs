using GraphQL.Types;
using Project_GraphQL_Web_API_Practice.Entities;

namespace Project_GraphQL_Web_API_Practice.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}
