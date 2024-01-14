using ManagingSalesOrderData.DAL.Database;
using ManagingSalesOrderData.DAL.Entities;
using ManagingSalesOrderData.DAL.Interfaces;

namespace ManagingSalesOrderData.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
