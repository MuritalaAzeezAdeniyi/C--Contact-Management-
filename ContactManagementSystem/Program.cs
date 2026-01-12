using ContactManagementSyatem.data.repository;
using ContactManagementSyatem.service;
using MongoDB.Driver;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb");
    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("MongoDb connection string is missing in appsettings.json");

    return new MongoClient(connectionString);
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("Contacts"); 
});


// Register your service (important, otherwise DI will fail)
builder.Services.AddScoped<IContactRepo, ContactRepo>();
builder.Services.AddScoped<IContactService, ContactServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

// ✅ Map your controllers
app.MapControllers();

app.Run();
