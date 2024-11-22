using Hw13;
using Hw13.Entities;
using Hw13.Infrastructure;
using Hw13.Repositories;
using Hw13.Service;
using Hw13.Storage;
using Microsoft.Identity.Client.Extensions.Msal;

string firstName = string.Empty;
string lastName = string.Empty;
string userName = string.Empty;
string password = string.Empty;
Result Register = null;
Result Login = null;


MemberService memberService = new MemberService();
BookService bookService = new BookService();
AdminService adminService = new AdminService();
AppDbContext c = new AppDbContext();  









while (true)
{
    Console.Clear();
    Console.WriteLine("1) Login");
    Console.WriteLine("2) Register");
    Console.Write("Please Select Number : ");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.Clear();
            LoginMenu();
            break;
        case 2:
            Console.Clear();
            RegisterMenu();
            break;

    }

    while (CurrentUser.OnlineUser != null)
    {
        if (CurrentUser.OnlineUser is Member)
        {
            if (memberService.CheckAccountTime().IsSucces)
            {
                MemberMenu();
                int option2 = Convert.ToInt32(Console.ReadLine());
                switch (option2)
                {
                    case 1:
                        BorrowBook();
                        break;
                    case 2:
                        ReturnBook();
                        break;
                    case 3:
                        bookService.GetBorrowBook();
                        Console.ReadKey();
                        break;
                    case 4:
                        bookService.GetNotBorrowBook();
                        Console.ReadKey();
                        break;
                    case 5:
                        memberService.LogOut();
                        break;
                }
            }
            else
            {
                Console.WriteLine(memberService.CheckAccountTime().Message);
                Console.ReadKey();
                memberService.LogOut();
            }
           
        } else
        {
            AdminMenu();
            int option2 = Convert.ToInt32(Console.ReadLine());
            switch (option2)
            {
                case 1:
                    adminService.GetAllBook();
                    break;
                case 2:
                      
                    adminService.GetAllMember();
                    break;
                    case 3:
                    adminService.GetAllMember();
                    ChargeAccount();
                    break;
                case 4:
                    adminService.LogOut();
                    break;
               
            }
        }
    }
}


void ChargeAccount()
{
    Console.Write("Please Enter Id : ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Please Enter Day : ");
    int day = Convert.ToInt32(Console.ReadLine());
    adminService.ChargeAccount(id, day);
}
void MemberMenu()
{
    Console.Clear();
    Console.WriteLine("1)Borrow Book");
    Console.WriteLine("2)Return Book");
    Console.WriteLine($"3)Get List Of {CurrentUser.OnlineUser.UserName}");
    Console.WriteLine("4)Get List Of Library Book");
    Console.WriteLine("5)exit");
    Console.Write("Please Enter Option : ");


}
void AdminMenu()
{
    Console.WriteLine("1)Get List Of Library Book");
    Console.WriteLine("2)Get All User");
    Console.WriteLine("3)Charge Account");
    Console.WriteLine("4)exit");
    Console.Write("Please Enter Option : ");
}
void BorrowBook()
{
    bookService.GetNotBorrowBook();
    Console.Write("Please Enter By Id : ");
    int id = Convert.ToInt32(Console.ReadLine());
    bookService.BorrowBook(id);
}
void ReturnBook()
{
    bookService.GetBorrowBook();
    Console.Write("Please Enter By Id : ");
    int id = Convert.ToInt32(Console.ReadLine());
    bookService.ReturnBook(id);
}
void LoginMenu()
{
    Console.Write("1) Admin , 2) Member : ");
    int role = Convert.ToInt32(Console.ReadLine());
    Console.Write("Please Enter User Name : ");
    userName = Console.ReadLine();
    Console.Write("Please Enter Password : ");
    password = Console.ReadLine();
    switch (role)
    {
        case 1:
            Login = adminService.Login(userName, password);

            break;

        case 2:
            Login = memberService.Login(userName, password);
            break;
    }
    Console.WriteLine(Login.Message);
    Console.ReadKey();

}
void RegisterMenu()
{
    Console.Write("1) Admin , 2) Member : ");
    int role = Convert.ToInt32(Console.ReadLine());
    Console.Write("Please Enter User Name : ");
    userName = Console.ReadLine();
    Console.Write("Please Enter Password : ");
    password = Console.ReadLine();
    Console.Write("Please Enter First Name : ");
    switch (role)
    {
        case 1:
            Admin a = new Admin()
            {

                UserName = userName
            };
            Register = adminService.Register(a, password);

            break;

        case 2:
            firstName = Console.ReadLine();
            Console.Write("Please Enter Last Name : ");
            lastName = Console.ReadLine();
            Member m = new Member()
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                RegisterTime = DateTime.Now,
                DayAvalible = 30,
            };
            Register = memberService.Register(m, password);
            break;
    }
    Console.WriteLine(Register.Message);
    Console.ReadKey();
}


