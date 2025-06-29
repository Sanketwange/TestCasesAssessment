
using AuthService.Common;
using Microsoft.EntityFrameworkCore;
using OrderAPP.Entity;
using OrderAPP.Repo;
using Solution.Core.Entity;
using Solution.Persistence;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDb")));*/
//in memory data base
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseInMemoryDatabase("UserDb"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<UserRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
SeedData(app);

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

static void SeedData(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();

    if (!context.Users.Any())
    {
        context.Users.AddRange(
            new Users { Id = 1, FullName = "Test", Email = "test@example.com",Password="Test",Username="Test" ,Role=UserRolesEnum.User },
            new Users { Id = 2, FullName = "Admin", Email = "admin@example.com", Password = "Admin", Username = "Admin", Role = UserRolesEnum.Admin }
        );
        context.SaveChanges();
    }

    if (!context.Orders.Any())
    {
        context.Orders.Add(new Order
        {
            Id = 1,
            ProductName = "Laptop",
            Amount = 999.99M,
            IsPaid = false
        });
        context.SaveChanges();
    }
}
