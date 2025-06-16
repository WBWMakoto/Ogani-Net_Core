namespace WebApplication1.Models
{
    public class PaymentResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? OrderId { get; set; }
    }
}
