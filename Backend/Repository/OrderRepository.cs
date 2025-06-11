using Backend.Data;
using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }

        public async Task<DTOResponse> Create(Order data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                _context.Orders.Add(data);  
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = $"{err.Message}", StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public IQueryable<Order> GetAll()
        {
            try
            {
                return _context.Orders;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<Order?> GetOne(string id)
        {
            try
            {
                return await _context.Orders.FindAsync(id);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<DTOResponse> Update(Order data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                if (await GetOne(data.ID) == null)
                    return new DTOResponse { Message = "Order does not exist.", StatusCode = StatusCodes.Status404NotFound };

                data.UpdateAt = DateTime.Now;

                _context.Orders.Update(data);
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
