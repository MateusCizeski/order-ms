namespace order_ms.DTOs
{
    public class EditOrderDTO
    {
        public int Id { get; set; }
        public int CustumerId { get; set; }
        public decimal Total { get; set; }
    }
}
