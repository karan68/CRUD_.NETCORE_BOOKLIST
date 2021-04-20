using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList_Razor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db; //using dependency injection

        public EditModel(ApplicationDbContext db)
        {
            _db = db; // we are using dependency injection and injecting the db present in server over here, and as we declared it readonly,
                      // In readonly fields, we can assign values in declaration and in the contructor part.
                      //if we had not used injection we would have to create an object of the applicationDb and dispose it and then do eg.vidly .net framework
        }
        [BindProperty] //Model binder works as a middleman to map the incoming HTTP request with Controller action method.
        public Book Book { get; set; }
        public async Task OnGet( int id)
        {
            Book = await _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }

    }
}
