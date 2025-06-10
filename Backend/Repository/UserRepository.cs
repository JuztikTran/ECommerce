using Backend.Data;
using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }

        public async Task<DTOResponse> Create(User user)
        {
            if (user == null)
                return new DTOResponse { StatusCode = StatusCodes.Status400BadRequest, Message = "Invalid data request." };
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new DTOResponse { StatusCode = StatusCodes.Status201Created, Message = $"_id: {user.ID}" };
            }
            catch (Exception e)
            {
                return new DTOResponse { StatusCode = StatusCodes.Status500InternalServerError, Message = e.Message };
            }
        }

        public async Task<DTOResponse> Delete(string id)
        {
            try
            {
                var user = await GetOne(id);
                if (user == null)
                    return new DTOResponse { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist." };
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return new DTOResponse { StatusCode = StatusCodes.Status204NoContent };
            }
            catch (Exception e)
            {
                return new DTOResponse { StatusCode = StatusCodes.Status500InternalServerError, Message = e.Message };
            }
        }

        public IQueryable<User> GetAll()
        {
            try
            {
                return _context.Users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User?> GetOne(string id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
                throw new Exception(e.Message);
            }
        }

        public async Task<DTOResponse> Update(User user)
        {
            if (user == null)
                return new DTOResponse { StatusCode = StatusCodes.Status400BadRequest, Message = "Invalid data request." };
            try
            {
                var data = await GetOne(user.ID);
                if (data == null)
                    return new DTOResponse { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist." };
                user.UpdateAt = DateTime.MaxValue;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return new DTOResponse { StatusCode = StatusCodes.Status200OK, Message = $"_id: {user.ID}" };
            }
            catch (Exception e)
            {
                return new DTOResponse { StatusCode = StatusCodes.Status500InternalServerError, Message = e.Message };
            }
        }
    }
}
