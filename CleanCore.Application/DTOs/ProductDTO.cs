using CleanCore.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanCore.Application.DTOs; 
public class ProductDTO {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3)]
    [DisplayName("Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [MinLength(10)]
    [DisplayName("Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Column(TypeName = "decimal(18,2")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Description")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock is required.")]
    [Range(1,9999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }

    [MaxLength(250)]
    [DisplayName("Image")]
    public string Image { get; set; }

    [DisplayName("Categories")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    [DisplayName("Suppliers")]
    public int SupplierId { get; set; }
    
    public Supplier Supplier { get; set; }
}
