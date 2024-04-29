using Microsoft.EntityFrameworkCore;
using SUT23_TeknikButik.Data;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Services
{
    public class OrderRepository : ITeknikButik<Order>
    {
        private AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> Add(Order newEntity)
        {
            var result = await _appDbContext.Orders.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order> Delete(int id)
        {
            var result = await _appDbContext.Orders.FirstOrDefaultAsync( o => o.OrderId == id);
            if(result != null)
            {
                _appDbContext.Orders.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _appDbContext.Orders.Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> GetSingel(int id)
        {
            return await _appDbContext.Orders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<Order> Update(Order Entity)
        {
           var result = await _appDbContext.Orders.FirstOrDefaultAsync(o=> o.OrderId == Entity.OrderId);

            if (result != null)
            {
                result.OrderPlaced = Entity.OrderPlaced;
                result.Customer.Adress = Entity.Customer.Adress;
                result.Customer.Email = Entity.Customer.Email;

                return result;
            }
            return null;
        }
    }
}
