using Backend.Data;
using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.Repository
{
    public class CartRepository : ICartRepository
    {
        private AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }

        public async Task<DTOResponse> Create(Cart data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                _context.Carts.Add(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = $"{err.Message}", StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<DTOResponse> Delete(string id)
        {
            try
            {
                var data = await GetOne(id);
                if(data == null)
                    return new DTOResponse { Message = "Cart does not exist.", StatusCode = StatusCodes.Status404NotFound };

                _context.Carts.Remove(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { StatusCode = StatusCodes.Status204NoContent };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = $"{err.Message}", StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public IQueryable<Cart> GetAll()
        {
            try
            {
                return _context.Carts;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Cart?> GetOne(string id)
        {
            try
            {
                return await _context.Carts.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DTOResponse> Update(Cart data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                if(await GetOne(data.ID) == null)
                    return new DTOResponse { Message = "Cart does not exist.", StatusCode = StatusCodes.Status404NotFound };

                data.UpdateAt = DateTime.Now;

                _context.Carts.Update(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = $"{err.Message}", StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
