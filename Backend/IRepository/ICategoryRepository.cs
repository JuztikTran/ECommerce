using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.IRepository
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Task<Category?> GetOne(string id);
        Task<DTOResponse> Create(Category category);
        Task<DTOResponse> Update(Category category);
        Task<DTOResponse> Delete(string id);
    }
}
