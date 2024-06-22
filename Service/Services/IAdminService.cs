using Microsoft.EntityFrameworkCore;
using Service.Entities;

namespace Service.Services
{
    public interface IAdminService
    {
        Task<SuperAdmin> Login(string username, string password);
        Task<SuperAdmin> GetCurrentAdminInfor(Guid id);
        Task<List<Order>> GetTopHighestOrder(int topOption);
        Task<decimal[]> GetRevenueByCurrentMonth();
        Task<int[]> GetUserInCurrentMonth();
        Task<int[]> GetOrderInCurrentMonth();
        Task<int[]> GetShopInCurrentMonth();
        Task<List<Shop>> GetAllShop();
        Task<List<Order>> GetAllOrders();
        Task<List<User>> GetAllUser();
        Task<List<Category>> GetAllCategories();
        Task<List<Brand>> GetAllBrands();
    }
    public class AdminService : IAdminService
    {
        private readonly LookeachContext _context;

        public AdminService()
        {
            _context = new LookeachContext();
        }
        public async Task<SuperAdmin> Login(string username, string password)
        => await _context.SuperAdmins.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

        public async Task<SuperAdmin> GetCurrentAdminInfor(Guid id)
        => await _context.SuperAdmins.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Order>> GetTopHighestOrder(int topOption)
        {
            var orders = await _context.Orders.Include(x => x.User).OrderBy(x => x.Amount).ToListAsync();
            return orders.Take(topOption).Skip(0).ToList();
        }

        /// <summary>
        /// [0] amount this month, [1] revenue
        /// </summary>
        /// <returns></returns>
        public async Task<decimal[]> GetRevenueByCurrentMonth()
        {
            var month = DateTime.Now.Month;
            var lastMonth = month == 1 ? 12 : month - 1;
            var orderAmounLastMonth = (await _context.Orders.Where(x => x.CreatedOn.Month == month).ToListAsync()).Sum(x => x.Amount);
            var revenue = orderAmounLastMonth - (await _context.Orders.Where(x => x.CreatedOn.Month == lastMonth).ToListAsync()).Sum(x => x.Amount);
            return new decimal[] { orderAmounLastMonth, revenue };
        }

        /// <summary>
        /// [0] user this month, [1] difference
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetUserInCurrentMonth()
        {
            var month = DateTime.Now.Month;
            var lastMonth = month == 1 ? 12 : month - 1;
            var user = await _context.Users.Where(x => x.CreatedOn.Month == month).ToListAsync();
            var userLastMonth = await _context.Users.Where(x => x.CreatedOn.Month == lastMonth).ToListAsync();
            return new int[] { user.Count, user.Count - userLastMonth.Count };
        }

        /// <summary>
        /// [0] order this month, [1] difference
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetOrderInCurrentMonth()
        {
            var month = DateTime.Now.Month;
            var lastMonth = month == 1 ? 12 : month - 1;
            var orders = await _context.Orders.Where(x => x.CreatedOn.Month == month).ToListAsync();
            var ordersLastMonth = await _context.Orders.Where(x => x.CreatedOn.Month == lastMonth).ToListAsync();
            return new int[] { orders.Count, orders.Count - ordersLastMonth.Count };
        }

        /// <summary>
        /// [0] shop this month, [1] difference
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetShopInCurrentMonth()
        {
            var month = DateTime.Now.Month;
            var lastMonth = month == 1 ? 12 : month - 1;
            var shops = await _context.Shops.Where(x => x.CreatedOn != null && x.CreatedOn.Value.Month == month).ToListAsync();
            var shopsLastMonth = await _context.Orders.Where(x => x.CreatedOn.Month == lastMonth).ToListAsync();
            return new int[] { shops.Count, shops.Count - shopsLastMonth.Count };
        }

        public async Task<List<Shop>> GetAllShop()
           => await _context.Shops.ToListAsync();

        public async Task<List<Order>> GetAllOrders()
            => await _context.Orders.Include(x => x.User).ToListAsync();

        public async Task<List<User>> GetAllUser()
            => await _context.Users.ToListAsync();

        public async Task<List<Category>> GetAllCategories()
            => await _context.Categories.ToListAsync();

        public async Task<List<Brand>> GetAllBrands()
            => await _context.Brands.ToListAsync();
    }
}
