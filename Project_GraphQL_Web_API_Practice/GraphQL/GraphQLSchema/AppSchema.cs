using GraphQL.Types;
using Project_GraphQL_Web_API_Practice.GraphQL.GraphQLQueries;

namespace Project_GraphQL_Web_API_Practice.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
