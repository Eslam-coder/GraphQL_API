using GraphQL.Types;
using Project_GraphQL_Web_API_Practice.Entities;

namespace Project_GraphQL_Web_API_Practice.GraphQL.GraphQLTypes
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(account => account.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(account => account.Description).Description("Description property from the account object.");
            Field(account => account.Owner.Name, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field<AccountTypeEnumType>("Type", "Enumeration for the account type object.");
        }
    }
}
