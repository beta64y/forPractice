using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceOperatorTask
{
    internal class Book : IEntity
    {
        private static int IdCounter = 0;
        public int Id { get; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; } = false;



        public Book(string name, string authorName, int pageCount)
        {
            Id = IdCounter++;
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;

        }
        public string ShowInfo()
        {
            return $"{Id} {AuthorName} {Name} {PageCount}";
        }
        public static bool operator >(Book book1, Book book2)
        {
            return book1.PageCount > book2.PageCount;
        }
        public static bool operator <(Book book1, Book book2)
        {
            return book1.PageCount < book2.PageCount;
        }
    }
}
