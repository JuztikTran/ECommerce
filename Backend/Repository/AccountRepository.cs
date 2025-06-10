using Backend.Data;
using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }

        public async Task<DTOResponse> Delete(string accountID)
        {
            try
            {
                var account = await GetOne(accountID);
                if (account == null)
                    return new DTOResponse { StatusCode = StatusCodes.Status404NotFound, Message = "Account does not exist." };
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return new DTOResponse { StatusCode = StatusCodes.Status204NoContent };
            }
            catch (Exception e)
            {
                return new DTOResponse { StatusCode = StatusCodes.Status500InternalServerError, Message = e.Message };
            }
        }

        public Task<DTOResponse> ForgotPass(DTOAuth account)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAll()
        {
            try
            {
                return _context.Accounts;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Account?> GetOne(string id)
        {
            try
            {
                return await _context.Accounts.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DTOResponse> SignIn(DTOAuth account)
        {
            try
            {
                var data = await _context.Accounts
                    .Where(a => a.UserName == account.Username || a.Email == account.Username || a.ID == account.Username)
                    .FirstOrDefaultAsync();
                if (data == null)
                    return new DTOResponse { StatusCode = StatusCodes.Status401Unauthorized, Message = "Account does not exist." };

                if (!BCrypt.Net.BCrypt.Verify(account.Password, data.PasswordHash))
                    return new DTOResponse { StatusCode = StatusCodes.Status401Unauthorized, Message = "Data sign in is incorrect." };

                return new DTOResponse { StatusCode = StatusCodes.Status200OK, Message = "token" };
            }
            catch (Exception e)
            {
                return new DTOResponse { StatusCode = StatusCodes.Status500InternalServerError, Message = e.Message };
            }
        }

        public Task<DTOResponse> SignUp(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
