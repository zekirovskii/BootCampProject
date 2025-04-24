using BootCampProject.Entities;
using BootCampProject.Repositories.Interfaces;
using DataAccess.Contexts; // AppDbContext için gerekli

namespace BootCampProject.Repositories.EF
{
    public class EfApplicantRepository : EfRepositoryBase<Applicant>, IApplicantRepository
    {
        public EfApplicantRepository(AppDbContext context) : base(context) { } // ✅
    }
}