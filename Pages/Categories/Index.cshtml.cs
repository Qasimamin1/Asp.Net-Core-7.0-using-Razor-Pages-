using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWeb.Data;
using RazorWeb.Model;

namespace RazorWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //create a property that hold all categories 
        public IEnumerable<Category> Categories { get; set; }   

        public IndexModel(ApplicationDbContext db)
        {

            _db = db;   
        }
        // will reterive all categories 
        public void OnGet()
        {
            //retrive all list from categories .... 
            Categories = _db.Categories;    
        }
    }
}
