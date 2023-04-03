using Dapper;
using Microsoft.AspNetCore.Mvc;
using ORM.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ORM.Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {


        private readonly ILogger<BookController> _logger;
        private readonly IDbConnection connection;
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
            connection =
            new SqlConnection("Server=.;Database=PublisherDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        [HttpGet(Name = "Books")]
        public IEnumerable<Book> Get()
        {

            return connection.QueryAsync<Book>("select * from Books").Result.ToList();
        }
    }
}