using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWeb.Data;
using RazorWeb.Model;

namespace RazorWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
       
        public Category Category { get; set; }  
        public CreateModel(ApplicationDbContext db) {
            
            _db = db; 
        
        }   
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost() {

            if(Category.Name== Category.DisplayOrder.ToString())
            {

                ModelState.AddModelError("Category.Name", "The Display order cannot exactly match the Name");
            }
            if(ModelState.IsValid)
            { 
                //custom manually show error 
                

            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
                TempData["success"] = "Category Created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        
        }    

    }
}
