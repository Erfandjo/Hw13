using Hw13.Contracts;
using Hw13.Entities;
using Hw13.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hw13.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdminRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public Admin? GetForUserName(string userName)
        {
            return _appDbContext.Admins.AsNoTracking().FirstOrDefault(u => u.UserName == userName);
        }

        public bool Login(string userName, string pass)
        {
            return _appDbContext.Admins.AsNoTracking().Any(t => t.UserName == userName && t.Password == pass);

        }

        public void Register(Admin admin)
        {
            _appDbContext.Admins.Add(admin);
            _appDbContext.SaveChanges();
        }
    }
}

