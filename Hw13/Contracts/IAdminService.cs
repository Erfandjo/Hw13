using Hw13.Entities;

namespace Hw13.Contracts
{
    public interface IAdminService
    {
        public Result CheckUsername(string userName);
        public Result Login(string userName, string password);
        public Result Register(Admin user, string pass);
        public void LogOut();
    }
}
