using Backend.Data;
using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }

        public async Task<DTOResponse> Create(Address data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                _context.Addresses.Add(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = err.Message, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public Task<DTOResponse> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Address> GetAll()
        {
            try
            {
                return _context.Addresses;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Address?> GetOne(string id)
        {
            try
            {
                return await _context.Addresses.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
                throw new Exception(e.Message);
            }
        }

        public async Task<DTOResponse> Update(Address data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                if(await GetOne(data.ID) == null)
                    return new DTOResponse { Message = "Address does not exist", StatusCode = StatusCodes.Status404NotFound };

                data.UpdateAt = DateTime.Now;

                _context.Addresses.Update(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = err.Message, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
