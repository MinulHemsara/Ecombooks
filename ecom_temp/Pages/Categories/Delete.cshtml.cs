using ecom_temp.Data;
using ecom_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecom_temp.Pages.Categories
{

    [BindProperties]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(Category);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
