using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoloBooks.Models
{
    public class Author
    {
        [ScaffoldColumn(false)]
        public int AuthorID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
