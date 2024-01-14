using ManagingSalesOrderData.DAL.Database;
using ManagingSalesOrderData.DAL.Entities;
using ManagingSalesOrderData.DAL.Interfaces;

namespace ManagingSalesOrderData.DAL.Repositories
{
    public class SubElementRepository : GenericRepository<SubElement>, ISubElementRepository
    {
        public SubElementRepository(AppDbContext context) : base(context)
        {
        }
    }
}
