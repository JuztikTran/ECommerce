using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.IRepository
{
    public interface ICartRepository
    {
        IQueryable<Cart> GetAll();
        Task<Cart?> GetOne(string id);
        Task<DTOResponse> Create(Cart data);
        Task<DTOResponse> Update(Cart data);
        Task<DTOResponse> Delete(string id);
    }
}
