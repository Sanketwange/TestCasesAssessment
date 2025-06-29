using Microsoft.EntityFrameworkCore;
using OrderAPP.Entity;
using Solution.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTestCases
{
    public class OrderDbTests
    {
        private UserDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique DB per test
                .Options;

            return new UserDbContext(options);
        }

        [Fact]
        public async Task AddOrder_SavesAndRetrievesSuccessfully()
        {
            // Arrange
            var context = GetInMemoryDbContext();

            var newOrder = new Order
            {
                ProductName = "Wireless Mouse",
                Amount = 299.99M,
                IsPaid = false
            };

            // Act
            context.Orders.Add(newOrder);
            await context.SaveChangesAsync();

            var savedOrder = await context.Orders.FirstOrDefaultAsync(o => o.ProductName == "Wireless Mouse");

            // Assert
            Assert.NotNull(savedOrder);
            Assert.Equal("Wireless Mouse", savedOrder.ProductName);
            Assert.Equal(299.99M, savedOrder.Amount);
            Assert.False(savedOrder.IsPaid);
        }
    }
}
