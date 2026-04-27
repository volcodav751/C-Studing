using System;
using System.Collections.Generic;
using System.Text;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services
{
    public class BookProcessing
    {
        public List<Book> ListBook = new List<Book>();
        public void CreateBook(int id, string title, string author)
        {
             Book book = new Book
             {
                 Id = id,
                 Title = title,
                 Author = author
             };
            ListBook.Add(book);
        }
        public string PrintAllBooks()
        {
            if (ListBook.Count == 0)
            {
                foreach (Book book in ListBook)
                {
                    return $"Книга {book.Id} з назвою {book.Title} від автора {book.Author}";
                }
            }
            else return "Книг не знайдено";
            
        }
        public void DeleteBook(int bookid)
        {
            Book book = ListBook.FirstOrDefault(id=>id.Id == bookid);
            ListBook.Remove(book);
        }
    }
}
