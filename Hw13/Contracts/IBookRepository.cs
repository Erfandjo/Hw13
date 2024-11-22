using Hw13.Entities;

namespace Hw13.Contracts
{
    public interface IBookRepository
    {

        public void BorrowBook(int memberId, int bookId);

        public List<Book> GetNotBorrowBook();

        public void ReturnBook(int memberId, int bookId);
        public List<Book> GetBorrowBook(int memberId);
    }
}
