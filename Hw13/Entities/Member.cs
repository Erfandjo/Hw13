using System.ComponentModel.DataAnnotations;

namespace Hw13.Entities
{
    public class Member : User
    {
        [MaxLength(10)]
        public string? FirstName { get; set; }
        [MaxLength(10)]
        public string? LastName { get; set; }
        public List<Book> Books { get; set; }
        public DateTime RegisterTime { get; set; }
        public int DayAvalible { get; set; }
    }
}
