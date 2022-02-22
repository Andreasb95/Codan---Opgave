using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Logic
{
    public interface IBookLogic
    {
        IList<Book> GetAllBooks();

        IList<Book> GetBooksByTitle(string title);
    }
}
