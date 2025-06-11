using Backend.Data;
using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }

        public async Task<DTOResponse> CreateOption(ProductOption data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                _context.Options.Add(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = err.Message, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<DTOResponse> CreateProduct(Product data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                _context.Products.Add(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = err.Message, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<DTOResponse> DeleteOption(string id)
        {
            try
            {
                var data = await GetOneOption(id);
                if (data == null)
                    return new DTOResponse { Message = "Product option does not exist.", StatusCode = StatusCodes.Status404NotFound };

                _context.Options.Remove(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { StatusCode = StatusCodes.Status204NoContent };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = err.Message, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<DTOResponse> DeleteProduct(string id)
        {
            try
            {
                var data = await GetOneProduct(id);
                if (data == null)
                    return new DTOResponse { Message = "Product option does not exist.", StatusCode = StatusCodes.Status404NotFound };

                _context.Products.Remove(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { StatusCode = StatusCodes.Status204NoContent };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = err.Message, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public IQueryable<ProductOption> GetAllOption()
        {
            try
            {
                return _context.Options;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IQueryable<Product> GetAllProduct()
        {
            try
            {
                return _context.Products;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProductOption?> GetOneOption(string id)
        {
            try
            {
                return await _context.Options.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Product?> GetOneProduct(string id)
        {
            try
            {
                return await _context.Products.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DTOResponse> UpdateOption(ProductOption data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                if (await GetOneOption(data.ID) == null)
                    return new DTOResponse { Message = "Product option does not exist.", StatusCode = StatusCodes.Status404NotFound };

                data.UpdateAt = DateTime.Now;

                _context.Options.Update(data);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {data.ID}", StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception err)
            {
                return new DTOResponse { Message = err.Message, StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<DTOResponse> UpdateProduct(Product data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request.", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                if (await GetOneProduct(data.ID) == null)
                    return new DTOResponse { Message = "Product does not exist.", StatusCode = StatusCodes.Status404NotFound };

                data.UpdateAt = DateTime.Now;

                _context.Products.Update(data);
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
