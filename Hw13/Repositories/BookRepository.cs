using Hw13.Contracts;
using Hw13.Entities;
using Hw13.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hw13.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public void BorrowBook(int memberId, int bookId)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.Id == bookId && b.IsBorrowed == false);
            var member = _appDbContext.Members.FirstOrDefault(u => u.Id == memberId);
            if (member != null && book != null) 
            {
                book.Member = member;
                book.IsBorrowed = true;
            }
            _appDbContext.SaveChanges();
        }

        public List<Book> GetBorrowBook(int memberId)
        {
            var Books = _appDbContext.Books.Where(b => b.IsBorrowed == true && b.MemberId == memberId).AsNoTracking().ToList();
            return Books;
        }

        public List<Book> GetNotBorrowBook()
        {
            var Books = _appDbContext.Books.Where(b => b.IsBorrowed == false).AsNoTracking().ToList();
            return Books;
        }

        public void ReturnBook(int memberId, int bookId)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.Id == bookId && b.MemberId == memberId);

            if (book is not null)
            {
                book.IsBorrowed = false;
                book.Member = null;
                book.MemberId = null;
            }
            _appDbContext.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _appDbContext.Books.AsNoTracking().ToList();
        }
    }
}
