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
        [BindProperty] //we used the bind property as we can fetch the book model in the onpost action , if we didn't do it we would have to declare a new 
                       //book object inside the action like OnPost(Book bookObj)
        public Book Book { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() //we use iactionresult as it will be used to redirect to a new page
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
