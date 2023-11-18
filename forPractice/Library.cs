using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;


namespace InterfaceOperatorTask
{
    internal class Library : IEntity
    {
        static int IdCounter = 1;
        public int Id { get;}
        public int BookLimit { get; set; }
        private Book[] Books;
        public Library(int bookLimit)
        {
            Id = IdCounter++;
            BookLimit = bookLimit;
            Books = new Book[0];
        }
        public void AddBook(Book book)
        {
            if (Books.Length == BookLimit)
            {
                throw new CapacityLimitException("kitab qoymaga yer yoxdu abratni qayit eve");
            }
            if(SearchNotDeletedBookByNameInLibrary(book.Name))
            {
                throw new AlreadyExistsException("bu artiq var ");
            }
            Array.Resize(ref Books, Books.Length + 1);
            Books[Books.Length - 1] = book;



        }
        public bool SearchNotDeletedBookByNameInLibrary(string name)
        {
            foreach (var book in Books)
            {
                if (book.Name == name & !book.IsDeleted)
                {
                    return true;    
                }
            }
            return false;
        }
        public Book GetBookById(int id)
        {
            foreach (var book in Books)
            {
                if (book.Id == id & !book.IsDeleted)
                {
                    return book;
                }
            }
            throw new NotFoundException("tapilmadi");
        }

    }
}
