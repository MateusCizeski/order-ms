using MongoDB.Bson.Serialization.Attributes;

namespace order_ms.Models
{
    public class Order
    {
        [BsonId]
        public int Id { get; set; }
        public int CustumerId { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Itens { get; set; }
    }
}
