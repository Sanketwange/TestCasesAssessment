namespace OrderAPP.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
