using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XL;

namespace XLApi.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Service _xl;
        public BooksController(Service xl)
        {
            _xl = xl;
        }

        // GET: api/Books
        [HttpGet]
        [Route("api/Books")]
        public IEnumerable<Book> Get()
        {
            return _xl.GetBooks();
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("api/Books/{id}")]
        public Book Get(int id)
        {
            return _xl.GetBook(id);
        }
    }
}
