using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.IRepository
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User?> GetOne(string id);
        Task<DTOResponse> Create(User user);
        Task<DTOResponse> Update(User user);
        Task<DTOResponse> Delete(string id);
    }
}
