using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI.WebControls.WebParts;

namespace SOAPBookServer
{

    [WebService(Namespace = "http://example.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class LibraryService : WebService
    {
        // Simulación de base de datos en memoria
        private static List<Book> books = new List<Book>();

        [WebMethod]
        public string CreateBook(int id, string title, string author)
        {
            if (books.Exists(b => b.Id == id))
                return "Book with the same ID already exists.";

            books.Add(new Book { Id = id, Title = title, Author = author });
            return "Book created successfully.";
        }

        [WebMethod]
        public List<Book> GetBooks()
        {
            return books;
        }

        [WebMethod]
        public Book GetBook(int id)
        {
            return books.Find(b => b.Id == id);
        }

        [WebMethod]
        public string UpdateBook(int id, string title, string author)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return "Book not found.";

            book.Title = title;
            book.Author = author;
            return "Book updated successfully.";
        }

        [WebMethod]
        public string DeleteBook(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return "Book not found.";

            books.Remove(book);
            return "Book deleted successfully.";
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}