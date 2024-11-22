using Hw13.Contracts;
using Hw13.Entities;
using Hw13.Repositories;
using Hw13.Storage;

namespace Hw13.Service
{
    public class MemberService : IMemberService
    {
        IMemberRepository Repo;
        public MemberService()
        {
            Repo = new MemberRepository();
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

        public Result Register(Member user, string pass)
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

        public void GetMembers()
        {
            var list = Repo.GetAll();
            foreach (var member in list)
            {
                Console.WriteLine($"Id : {member.Id} , Name : {member.FirstName} {member.LastName} , User Name : {member.UserName}");
            }
        }

        public Result CheckAccountTime()
        {
            Member onlineUser = (Member) CurrentUser.OnlineUser;
            if (onlineUser.RegisterTime.Day + onlineUser.DayAvalible >= DateTime.Now.Day)
            {
                return new Result(true);
            }
            return new Result(false , "Please Charge Account");
        }
    }
}

