using CleanCore.Domain.Entities;
using CleanCore.Domain.Validation;
using FluentAssertions;

namespace CleanCore.Domain.Tests;

public class SupplierUnitTest1 {
    [Fact(DisplayName = "Create Supplier with valid state.")]
    public void CreateSupplier_ValidParameters_ResultObjectValidState() {
        Action action = () => new Supplier(1, "Supplier Name", "11110000222233");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Supplier with negative ID value.")]
    public void CreateSupplier_NegativeIdValue_DomainExceptionValidation() {
        Action action = () => new Supplier(-1, "Supplier Name", "11110000222233");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid id.");
    }

    [Fact(DisplayName = "Create Supplier with empty name value.")]
    public void CreateSupplier_EmptyNameValue_DomainExceptionValidation() {
        Action action = () => new Supplier(1, "", "11110000222233");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }

    [Fact(DisplayName = "Create Supplier with null name value.")]
    public void CreateSupplier_NullNameValue_DomainExceptionValidation() {
        Action action = () => new Supplier(1, null, "11110000222233");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }

    [Fact(DisplayName = "Create Supplier with short CNPJ value.")]
    public void CreateSupplier_ShortCNPJValue_DomainExceptionValidation() {
        Action action = () => new Supplier(1, "Supplier Name", "111100002222");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid. A CNPJ has 14 digits.");
    }

    [Fact(DisplayName = "Create Supplier with empty CNPJ value.")]
    public void CreateSupplier_EmptyCNPJValue_DomainExceptionValidation() {
        Action action = () => new Supplier(1, "Supplier Name", "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid CNPJ.");
    }

    [Fact(DisplayName = "Create Supplier with null CNPJ value.")]
    public void CreateSupplier_NullCNPJValue_DomainExceptionValidation() {
        Action action = () => new Supplier(1, "Supplier Name", null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid CNPJ.");
    }

    [Fact(DisplayName = "Update Supplier with empty CNPJ value.")]
    public void UpdateSupplier_EmptyCNPJValue_DomainExceptionValidation() {
        Supplier supplier = new Supplier(1, "Supplier Name", "11110000222233");
        Action action = () => supplier.Update("Supplier Name", "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid CNPJ.");
    }
    
    [Fact(DisplayName = "Update Supplier with empty CNPJ value.")]
    public void UpdateCategory_EmptyNameValue_DomainExceptionValidation() {
        Supplier supplier = new Supplier(1, "Supplier Name", "11110000222233");
        Action action = () => supplier.Update("Supplier Name", null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid CNPJ.");
    }
}