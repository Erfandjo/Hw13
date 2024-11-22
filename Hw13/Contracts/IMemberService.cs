using Hw13.Entities;

namespace Hw13.Contracts
{
    public interface IMemberService
    {
        public Result CheckUsername(string userName);
        public Result Login(string userName, string password);
        public Result Register(Member user, string pass);
        public void LogOut();
        public void GetMembers();
    }
}
