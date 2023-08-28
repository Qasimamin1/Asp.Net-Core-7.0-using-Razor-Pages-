using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWeb.Data;
using RazorWeb.Model;
using System.Threading.Tasks;

namespace RazorWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display order cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
