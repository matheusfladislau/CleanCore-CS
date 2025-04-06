using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanCore.Application.DTOs; 
public class CategoryDTO {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3)]
    [DisplayName("Name")]
    public string Name { get; set; }
}
