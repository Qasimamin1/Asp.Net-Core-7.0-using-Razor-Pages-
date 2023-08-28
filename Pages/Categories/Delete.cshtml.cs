using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWeb.Data;
using RazorWeb.Model;
using System.Threading.Tasks;

namespace RazorWeb.Pages.Categories
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

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _db.Categories.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var CategoryFromDb = _db.Categories.Find(Category.Id);
            if (CategoryFromDb != null)
            {
                _db.Categories.Remove(CategoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted Successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
