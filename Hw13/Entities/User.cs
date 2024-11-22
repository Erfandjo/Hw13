using System.ComponentModel.DataAnnotations;

namespace Hw13.Entities

{
    public class User
    {
      
        public int Id { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }


        public Result SetPassword(string password)
        {
            if (password.Length >= 3)
            {
                Password = password;
                return new Result(true);
            }
            return new Result(false, "Password Must Be More Than 3 Characters");
        }

    }
}
