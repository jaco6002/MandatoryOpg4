using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRestService.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        //had to add my book manually because dll used .net 3.1 og jeg fik lavet min rest service i 2.2
        private static List<Book> Books = new List<Book>()
        {
            new Book("title", "author", 132, "1234567890123"),
            new Book("title", "Jacob M", 10, "1234561110123"),
            new Book("title", "Anders H", 999, "1222222222222"),
            new Book("title", "Carl D", 13, "1233333333333"),
            new Book("title", "Jonas", 25, "1234444444444")
            
        };

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Books;
        }

        // GET api/<controller>/5
        [HttpGet("{isbn}")]
        public Book Get(string isbn)
        {
            return Books.Find(b=>b.Isbn13==isbn);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            Books.Add(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody]Book value)
        {
            Book book = Get(isbn);
            if (book != null)
            {
                book.Isbn13 = value.Isbn13;
                book.Title = value.Title;
                book.Author = value.Author;
                book.Pages = value.Pages;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            Books.Remove(Get(isbn));
        }
    }
}
