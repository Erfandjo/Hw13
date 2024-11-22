using System.ComponentModel.DataAnnotations;

namespace Hw13.Entities
{
    public class Book
    {
       
        public int Id { get; set; }
        public int? MemberId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Writer { get; set; }
        public int Pages { get; set; }
        public bool IsBorrowed { get; set; }
        public Member? Member  { get; set; }

    }

}
