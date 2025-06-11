using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.IRepository
{
    public interface IAddressRepository
    {
        IQueryable<Address> GetAll();
        Task<Address?> GetOne(string id);
        Task<DTOResponse> Create(Address data);
        Task<DTOResponse> Update(Address data);
        Task<DTOResponse> Delete(string id);
    }
}
