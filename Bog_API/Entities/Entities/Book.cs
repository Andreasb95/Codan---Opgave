using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Book 
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateTime Publish_Date { get; set; }

        public string Description { get; set; }
    }
}
