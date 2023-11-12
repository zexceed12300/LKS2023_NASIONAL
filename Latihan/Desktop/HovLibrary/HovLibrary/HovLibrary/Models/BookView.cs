using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HovLibrary.Models
{
    class BookView
    {
        public int id { get; set; }
        public string language { get; set; }
        public string title { get; set; }
        public string isbn { get; set; }
        public string isbn13 { get; set; }
        public string authors { get; set; }
        public string publisher { get; set; }
        public DateTime publication_date { get; set; }
        public int number_of_pages { get; set; }
        public double average_rating { get; set; }
        public int ratings_count { get; set; }
    }
}
