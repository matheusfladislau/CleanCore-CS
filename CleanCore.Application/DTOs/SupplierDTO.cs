using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanCore.Application.DTOs; 
public class SupplierDTO {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [DisplayName("Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "CNPJ is required.")]
    [Length(14, 14, ErrorMessage = "CNPJ must have 14 digits.")]
    [DisplayName("CNPJ")]
    public string CNPJ { get; set; }
}
