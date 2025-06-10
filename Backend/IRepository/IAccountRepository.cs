using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.IRepository
{
    public interface IAccountRepository
    {
        IQueryable<Account> GetAll();
        Task<Account?> GetOne(string id);
        Task<DTOResponse> SignIn(DTOAuth account);
        Task<DTOResponse> SignUp(Account account);
        Task<DTOResponse> ForgotPass(DTOAuth account);
        Task<DTOResponse> Delete(string accountID);
    }
}
