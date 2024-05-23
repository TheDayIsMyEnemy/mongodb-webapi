using WebApi.Options;
using MongoDb.Data.Interfaces;
using MongoDb.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(builder.Configuration.GetSection(MongoDbOptions.SectionKey).Get<MongoDbOptions>()!);
builder.Services.AddSingleton(typeof(IRepository<>), typeof(MongoDbRepository<>));

builder.Services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
