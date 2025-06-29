using OrderAPP.Entity;
using OrderAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTestCases
{
    public class PaymentServiceTests
    {
        private readonly PaymentService _paymentService;

        public PaymentServiceTests()
        {
            _paymentService = new PaymentService();
        }

        [Fact]
        public void ProcessPayment_ThrowsException_WhenOrderIsNull()
        {
            // Arrange
            Order? order = null;

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                _paymentService.ProcessPayment(order));

            Assert.Equal("Order cannot be null.", exception.Message);
        }

        [Fact]
        public void ProcessPayment_ThrowsException_WhenOrderIsAlreadyPaid()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                ProductName = "Test Product",
                Amount = 100,
                IsPaid = true
            };

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                _paymentService.ProcessPayment(order));

            Assert.Equal("Order has already been paid.", exception.Message);
        }

        [Fact]
        public void ProcessPayment_SetsIsPaidTrue_WhenValid()
        {
            // Arrange
            var order = new Order
            {
                Id = 2,
                ProductName = "Valid Product",
                Amount = 250,
                IsPaid = false
            };

            // Act
            _paymentService.ProcessPayment(order);

            // Assert
            Assert.True(order.IsPaid);
        }
    }
}
