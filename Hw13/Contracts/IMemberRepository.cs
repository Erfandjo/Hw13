using Hw13.Entities;

namespace Hw13.Contracts
{
    public interface IMemberRepository
    {
        public bool Login(string userName, string pass);
        public void Register(Member member);
        public Member GetForUserName(string userName);
        public List<Member> GetAll();
    }
}
