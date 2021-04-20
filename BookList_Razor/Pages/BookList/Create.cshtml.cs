using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList_Razor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db; //using dependency injection

        public CreateModel(ApplicationDbContext db)
        {
            _db = db; // we are using dependency injection and injecting the db present in server over here, and as we declared it readonly,
                      // In readonly fields, we can assign values in declaration and in the contructor part.
                      //if we had not used injection we would have to create an object of the applicationDb and dispose it and then do eg.vidly .net framework
        }
        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Book.Add(Book);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
