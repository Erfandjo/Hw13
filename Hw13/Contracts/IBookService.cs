using Hw13.Entities;

namespace Hw13.Contracts
{
    public interface IBookService
    {
        public void BorrowBook(int bookId);

        public void GetNotBorrowBook();

        public void ReturnBook(int bookId);
        public void GetBorrowBook();
    }
}
