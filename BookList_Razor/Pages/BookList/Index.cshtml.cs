using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; //using dependency injection

        public IndexModel(ApplicationDbContext db)
        {
            _db = db; // we are using dependency injection and injecting the db present in server over here, and as we declared it readonly,
                      // In readonly fields, we can assign values in declaration and in the contructor part.
                      //if we had not used injection we would have to create an object of the applicationDb and dispose it and then do eg.vidly .net framework
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync(); //it returns all the book o books asynchronously and awaits until done
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);//find the id in database
            if (book == null)
            {
                return NotFound();
            }
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
