using OrderAPP.Entity;

namespace OrderAPP.Services
{
    public class PaymentService
    {
        public void ProcessPayment(Order? order)
        {
            if (order == null)
                throw new InvalidOperationException("Order cannot be null.");

            if (order.IsPaid)
                throw new InvalidOperationException("Order has already been paid.");

            // Simulate payment processing
            order.IsPaid = true;
        }
    }
}
