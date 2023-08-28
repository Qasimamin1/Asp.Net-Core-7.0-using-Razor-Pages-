using System.ComponentModel.DataAnnotations;

namespace RazorWeb.Model
{
    public class Category
    {
        [Key]

        public int Id { get; set; }

        [Required]  
        public string Name { get; set; }
        // we can display name of our own choice
        [Display(Name="Display Order")]
        [Range(1,100, ErrorMessage ="Display Order must be in range of 1-100 !!!")]
        public int DisplayOrder {  get ; set; } 

    }
}
 