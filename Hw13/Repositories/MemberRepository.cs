using Hw13.Contracts;
using Hw13.Entities;
using Hw13.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hw13.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _appDbContext;

        public MemberRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public List<Member> GetAll()
        {
            return _appDbContext.Members.AsNoTracking().ToList();
        }

        public Member? GetForUserName(string userName)
        {
            return _appDbContext.Members.AsNoTracking().FirstOrDefault(u => u.UserName == userName);
        }

        public bool Login(string userName, string pass)
        {
            return _appDbContext.Members.AsNoTracking().Any(t => t.UserName == userName && t.Password == pass);

        }

        public void Register(Member member)
        {
            _appDbContext.Members.Add(member);
            _appDbContext.SaveChanges();
        }


        public void ChargeAccount(int memberId , int date)
        {
            var member =  _appDbContext.Members.FirstOrDefault(u => u.Id == memberId);
            member.DayAvalible += date;
            _appDbContext.SaveChanges();
        }
    }
}

