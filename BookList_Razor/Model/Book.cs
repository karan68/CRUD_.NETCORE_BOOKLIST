using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList_Razor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        public string Name { get; set; }

        public string ISBN { get; set; }
    
        public String Author { get; set; }
    }
}
