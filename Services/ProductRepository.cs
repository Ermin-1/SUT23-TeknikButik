using Microsoft.EntityFrameworkCore;
using SUT23_TeknikButik.Data;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Services
{
    public class ProductRepository : ITeknikButik<Product>
    {
        private AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Product> Add(Product newEntity)
        {
            var result = await _appDbContext.Products.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Product> Delete(int id)
        {
           var resultat = await _appDbContext.Products.FirstOrDefaultAsync
                (p => p.ProductId == id);
            if (resultat != null)
            {
                _appDbContext.Products.Remove(resultat);
                await _appDbContext.SaveChangesAsync();
                return resultat;
            }

            return null;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetSingel(int id)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> Update(Product Entity)
        {
           var result = await _appDbContext.Products.FirstOrDefaultAsync
                (p =>p.ProductId == Entity.ProductId);
            if (result != null)
            {
                result.ProductName = Entity.ProductName;
                result.Price = Entity.Price;
                result.Category = Entity.Category;  

                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
