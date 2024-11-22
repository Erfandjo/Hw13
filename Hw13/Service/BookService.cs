using Hw13.Contracts;
using Hw13.Entities;
using Hw13.Repositories;
using System.Net;

namespace Hw13.Service
{
    public class BookService : IBookService
    {
        IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }
        public void BorrowBook(int bookId)
        {
            var currentUser = Storage.CurrentUser.OnlineUser;
            _bookRepository.BorrowBook(currentUser.Id, bookId);
        }

        public void GetBorrowBook()
        {
            var currentUser = Storage.CurrentUser.OnlineUser;
            var list = _bookRepository.GetBorrowBook(currentUser.Id);
            foreach (var item in list)
            {
                Console.WriteLine($"Id : {item.Id} , Name : {item.Name} , Writer : {item.Writer} , Pages : {item.Pages}");
            }
        }

        public void GetNotBorrowBook()
        {
            var list = _bookRepository.GetNotBorrowBook();
            foreach (var item in list)
            {
                Console.WriteLine($"Id : {item.Id} , Name : {item.Name} , Writer : {item.Writer} , Pages : {item.Pages}");
            }
        }

        public void ReturnBook(int bookId)
        {
            var currentUser = Storage.CurrentUser.OnlineUser;
            _bookRepository.ReturnBook(currentUser.Id, bookId);
        }
    }
}
