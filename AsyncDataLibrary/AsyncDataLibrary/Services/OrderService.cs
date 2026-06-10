using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public class OrderService
{
    private readonly IRepository<Order> _repository;

    public OrderService(IRepository<Order> repository)
    {
        _repository = repository;
    }

    public List<Order> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Order? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    public void Add(Order order)
    {
        Validate(order);
        _repository.Add(order);
    }

    public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        Validate(order);
        await _repository.AddAsync(order, cancellationToken);
    }

    public bool Update(Order order)
    {
        Validate(order);
        return _repository.Update(order);
    }

    public async Task<bool> UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        Validate(order);
        return await _repository.UpdateAsync(order, cancellationToken);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }

    public async Task<bool> ChangeStatusAsync(int orderId, OrderStatus status, CancellationToken cancellationToken = default)
    {
        Order? order = await _repository.GetByIdAsync(orderId, cancellationToken);
        if (order is null)
        {
            return false;
        }

        order.Status = status;
        return await _repository.UpdateAsync(order, cancellationToken);
    }

    private static void Validate(Order order)
    {
        if (order.UserId <= 0)
        {
            throw new ArgumentException("Потрібно вибрати користувача.");
        }

        if (order.BookId <= 0)
        {
            throw new ArgumentException("Потрібно вибрати книгу.");
        }
    }
}
