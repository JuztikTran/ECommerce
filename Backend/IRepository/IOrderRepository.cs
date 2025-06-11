using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.IRepository
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        Task<Order?> GetOne(string id);
        Task<DTOResponse> Create(Order order);
        Task<DTOResponse> Update(Order order);
    }
}
