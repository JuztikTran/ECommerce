using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.IRepository
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAllProduct();
        IQueryable<ProductOption> GetAllOption();
        Task<Product?> GetOneProduct(string id);
        Task<ProductOption?> GetOneOption(string id);
        Task<DTOResponse> CreateProduct(Product data);
        Task<DTOResponse> CreateOption(ProductOption data);
        Task<DTOResponse> UpdateProduct(Product product);
        Task<DTOResponse> UpdateOption(ProductOption option);
        Task<DTOResponse> DeleteProduct(string id);
        Task<DTOResponse> DeleteOption(string id);
    }
}
