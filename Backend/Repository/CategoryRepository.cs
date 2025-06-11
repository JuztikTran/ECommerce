using Backend.Data;
using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;

namespace Backend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(_context));
        }

        public async Task<DTOResponse> Create(Category category)
        {
            if (category == null)
                return new DTOResponse { Message = "Invalid data request", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return new DTOResponse { Message = $"_id: {category.ID}" , StatusCode = StatusCodes.Status201Created};
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

        public IQueryable<Category> GetAll()
        {
            try
            {
                return _context.Categories;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Category?> GetOne(string id)
        {
            try
            {
                return await _context.Categories.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DTOResponse> Update(Category data)
        {
            if (data == null)
                return new DTOResponse { Message = "Invalid data request", StatusCode = StatusCodes.Status400BadRequest };
            try
            {
                if(await GetOne(data.ID) == null)
                    return new DTOResponse { Message = "Category does not exist.", StatusCode = StatusCodes.Status404NotFound };

                _context.Categories.Add(data);
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
