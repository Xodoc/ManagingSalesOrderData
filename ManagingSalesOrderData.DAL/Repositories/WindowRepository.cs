using ManagingSalesOrderData.DAL.Database;
using ManagingSalesOrderData.DAL.Entities;
using ManagingSalesOrderData.DAL.Interfaces;

namespace ManagingSalesOrderData.DAL.Repositories
{
    public class WindowRepository : GenericRepository<Window>, IWindowRepository
    {
        public WindowRepository(AppDbContext context) : base(context)
        {
        }
    }
}
