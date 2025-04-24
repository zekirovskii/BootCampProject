using BootCampProject.Entities;
using BootCampProject.Repositories.Interfaces;
using DataAccess.Contexts; // AppDbContext için gerekli

namespace BootCampProject.Repositories.EF
{
    public class EfEmployeeRepository : EfRepositoryBase<Employee>, IEmployeeRepository
    {
        public EfEmployeeRepository(AppDbContext context) : base(context) { } // ✅ DÜZELTİLDİ
    }
}