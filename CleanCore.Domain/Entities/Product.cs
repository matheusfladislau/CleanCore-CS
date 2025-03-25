using CleanCore.Domain.Validation;

namespace CleanCore.Domain.Entities;

public sealed class Product : Entity {
    public Product(int id, string name, string description, decimal price, 
            int stock, string image) {

        ValidateId(id);
        ValidateName(name);
        ValidateDescription(description);
        ValidatePrice(price);
        ValidateStock(stock);
        ValidateImage(image);
        
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Stock = stock;
        this.Image = image;
    }

    public Product(string name, string description, decimal price, 
            int stock, string image) {
        
        ValidateName(name);
        ValidateDescription(description);
        ValidatePrice(price);
        ValidateStock(stock);
        ValidateImage(image);
        
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Stock = stock;
        this.Image = image;
    }


    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }


    public void Update(string name, string description, decimal price, 
            int stock, string image, int categoryId) {
        
        ValidateName(name);
        ValidateDescription(description);
        ValidatePrice(price);
        ValidateStock(stock);
        ValidateImage(image);
        
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Stock = stock;
        this.Image = image;
        this.CategoryId = categoryId;
    }

    private void ValidateId(int id) {
        DomainExceptionValidation.When(id < 0,
                "Invalid id.");
    }

    private void ValidateName(string name) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.");

        DomainExceptionValidation.When(name.Length < 3,
                "Name is too short. Minimum three characters.");
    }

    private void ValidateDescription(string description) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description.");

        DomainExceptionValidation.When(description.Length < 10,
                "Description is too short. Minimum ten characters.");
    }

    private void ValidatePrice(decimal price) {
        DomainExceptionValidation.When(price < 0,
                "Invalid price. Must be higher than 0.");
    }

    private void ValidateStock(int stock) {
        DomainExceptionValidation.When(stock < 0,
                "Invalid stock. Must be higher than 0.");
    }

    private void ValidateImage(string image) {
        DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image. Image too long.");
    }
}
