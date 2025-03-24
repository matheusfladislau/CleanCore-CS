using CleanCore.Domain.Entities;
using CleanCore.Domain.Validation;
using FluentAssertions;

namespace CleanCore.Domain.Tests;
public class ProductUnitTest1 {
    [Fact(DisplayName = "Create product with valid state.")]
    public void CreateProduct_ValidParameters_ResultObjectValidState() {
        Action action = () => new Product(1, "Product Name", "Product Description", 10, 20, "Product image");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create product with negative ID value.")]
    public void CreateProduct_NegativeIdValue_DomainExceptionValidation() {
        Action action = () => new Product(-1, "Product Name", "Product Description", 10, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid id.");
    }

    [Fact(DisplayName = "Create product with short name value.")]
    public void CreateProduct_ShortNameValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "PN", "Product Description", 10, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Name is too short. Minimum three characters.");
    }

    [Fact(DisplayName = "Create product with empty name value.")]
    public void CreateProduct_EmptyNameValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "", "Product Description", 10, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }

    [Fact(DisplayName = "Create product with null name value.")]
    public void CreateProduct_NullNameValue_DomainExceptionValidation() {
        Action action = () => new Product(1, null, "Product Description", 10, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }

    [Fact(DisplayName = "Create product with empty description value.")]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "Product Name", "PD", 10, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Description is too short. Minimum ten characters.");
    }

    [Fact(DisplayName = "Create product with empty description value.")]
    public void CreateProduct_EmptyDescriptionValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "Product Name", "", 10, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description.");
    }

    [Fact(DisplayName = "Create product with null description value.")]
    public void CreateProduct_NullDescriptionValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "Product Name", null, 10, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description.");
    }

    [Fact(DisplayName = "Create product with negative price value.")]
    public void CreateProduct_NegativePriceValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "Product Name", "Product Description", -1, 20, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid price. Must be higher than 0.");
    }

    [Fact(DisplayName = "Create product with negative stock value.")]
    public void CreateProduct_NegativeStockValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "Product Name", "Product Description", 10, -1, "Product image");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock. Must be higher than 0.");
    }

    [Fact(DisplayName = "Create product with empty image value.")]
    public void CreateProduct_EmptyImageValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "Product Name", "Product Description", 10, 20, "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image.");
    }

    [Fact(DisplayName = "Create product with null image value.")]
    public void CreateProduct_NullImageValue_DomainExceptionValidation() {
        Action action = () => new Product(1, "Product Name", "Product Description", 10, 20, null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image.");
    }
}