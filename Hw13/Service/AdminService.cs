using Hw13.Contracts;
using Hw13.Entities;
using Hw13.Repositories;
using Hw13.Storage;

namespace Hw13.Service
{
    public class AdminService : IAdminService
    {
        IAdminRepository Repo;
        public AdminService()
        {
            Repo = new AdminRepository();
        }

        public Result CheckUsername(string userName)
        {
            if (Repo.GetForUserName(userName) is not null)
            {

                return new Result(true, "User Name Exist");

            }

            return new Result(false);
        }

        public Result Login(string userName, string password)
        {
            var user = Repo.GetForUserName(userName);
            if (Repo.Login(userName, password))
            {
                CurrentUser.OnlineUser = user;
                return new Result(true, "Success");
            }
            return new Result(false, "UserName or Password Incorrect.");
        }

        public Result Register(Admin user, string pass)
        {
            var Result = user.SetPassword(pass);
            if (!CheckUsername(user.UserName).IsSucces)
            {
                if (Result.IsSucces)
                {
                    Repo.Register(user);
                    return new Result(true, "Success");
                }
                else
                {
                    return new Result(false, Result.Message);
                }
            }
            else
            {
                return CheckUsername(user.UserName);
            }

        }

        public void LogOut()
        {
            CurrentUser.OnlineUser = null;
        }

        public void GetAllMember()
        {
            MemberRepository memberRepository = new MemberRepository();
            var list = memberRepository.GetAll();
            foreach (var member in list)
            {
                Console.WriteLine($"Id : {member.Id} , Name : {member.FirstName} {member.LastName} , User Name : {member.UserName} , DayAvalible : {member.DayAvalible - (DateTime.Now.Day - member.RegisterTime.Day) }");
            }
        }

        public void GetAllBook()
        {
            BookRepository bookRepository = new BookRepository();
            var list = bookRepository.GetAll();
            foreach (var book in list)
            {
                Console.WriteLine($"Id : {book.Id} , Name : {book.Name} , Writer : {book.Writer} Pages : {book.Pages} , IsBorrow : {book.IsBorrowed}");
            }
        }

        public void ChargeAccount(int Id , int date)
            {
            MemberRepository memberRepository = new MemberRepository();
            memberRepository.ChargeAccount(Id, date);
        }
        

    }
}

