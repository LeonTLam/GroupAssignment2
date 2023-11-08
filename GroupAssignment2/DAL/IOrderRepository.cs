using GroupAssignment2.Models;

namespace GroupAssignment2.DAL
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>?> GetAll();
        Task<Housing?> GetHousingById(int id);
        Task<Order?> GetOrderById(int id);
        Task<bool> CreateOrder(Order order);
        Task<bool> Delete(int id);
    }
}
