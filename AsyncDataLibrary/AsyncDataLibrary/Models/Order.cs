using AsyncDataLibrary.Attributes;
using AsyncDataLibrary.Interfaces;

namespace AsyncDataLibrary.Models;

[StorageFile("orders.json")]
public class Order : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; } = OrderStatus.Created;
}
