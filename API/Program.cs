using API.Mapper;
using Data;
using Data.DbContext;
using Domain;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<ISupplierData, SupplierData>();
builder.Services.AddScoped<ISupplierDomain, SupplierDomain>();

//MySQL Connection
var connectionString = builder.Configuration.GetConnectionString("databasedb");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<DatabaseDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

builder.Services.AddAutoMapper(
    typeof(ModelToRequest),
    typeof(RequestToAPI)
);

var app = builder.Build();

using(var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<DatabaseDBContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();