using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.Model;

namespace ORM.EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {


        private readonly ILogger<BookController> _logger;
        private readonly PublisherDbContext _publisherDbContext;

        public BookController(ILogger<BookController> logger,PublisherDbContext publisherDbContext)
        {
            _logger = logger;
            this._publisherDbContext = publisherDbContext;
        }

        [HttpGet(Name = "Books")]
        public IEnumerable<Book> Get()
        {
            return _publisherDbContext.Books.ToList();
        }
    }
}