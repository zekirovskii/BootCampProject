using BootCampProject.Entities;
using BootCampProject.Repositories.Interfaces;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BootCampProject.Repositories.EF
{
    public class EfInstructorRepository : EfRepositoryBase<Instructor>, IInstructorRepository
    {
        public EfInstructorRepository(AppDbContext context) : base(context) { }

    }
}