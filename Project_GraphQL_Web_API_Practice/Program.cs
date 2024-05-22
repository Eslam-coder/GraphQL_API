using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_GraphQL_Web_API_Practice.Contracts;
using Project_GraphQL_Web_API_Practice.Entities.Context;
using Project_GraphQL_Web_API_Practice.GraphQL.GraphQLSchema;
using Project_GraphQL_Web_API_Practice.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLApiDB")));

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

//GraphQL
builder.Services.AddScoped<AppSchema>();
//builder.Services.AddGraphQL(o => { o.ExposeExceptions = false; })
//                .AddGraphTypes(ServiceLifetime.Scoped)
//                .AddDataLoader();
builder.Services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
                .AddDataLoader();

//builder.Services.AddControllers()
//        .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

app.MapControllers();

app.Run();
