using System.Xml.Linq;
using Entities.Entities;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookLogic _bookLogic;

        public BookController(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetAllBooks()
        {
            var listOfBooks = _bookLogic.GetAllBooks();
            return ListCount_Return_Requst(listOfBooks);
        }

        [HttpGet]
        [Route("{title}")]
        public async Task<ActionResult<Book>> GetBooksByTitle(string title)
        {
            title = FirstCaseToUpper(title);
            var listOfBooks = _bookLogic.GetBooksByTitle(title);
            return ListCount_Return_Requst(listOfBooks);
        }


        private ActionResult ListCount_Return_Requst(IList<Book> books)
        {
            if (books.Count == 0)
                return BadRequest();
            return Ok(books);

        }

        private string FirstCaseToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
}
}
