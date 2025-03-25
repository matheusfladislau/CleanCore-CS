using CleanCore.Domain.Entities;
using CleanCore.Domain.Validation;
using FluentAssertions;

namespace CleanCore.Domain.Tests;

public class CategoryUnitTest1 {
    [Fact(DisplayName = "Create Category with valid state.")]
    public void CreateCategory_ValidParameters_ResultObjectValidState() {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category with negative ID value.")]
    public void CreateCategory_NegativeIdValue_DomainExceptionValidation() {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid id.");
    }

    [Fact(DisplayName = "Create Category with short name.")]
    public void CreateCategory_ShortNameValue_DomainExceptionValidation() {
        Action action = () => new Category(1, "CN");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Name is too short. Minimum three characters.");
    }

    [Fact(DisplayName = "Create Category with empty name value.")]
    public void CreateCategory_EmptyNameValue_DomainExceptionValidation() {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }

    [Fact(DisplayName = "Create Category with null name value.")]
    public void CreateCategory_NullNameValue_DomainExceptionValidation() {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }

    [Fact(DisplayName = "Update Category with empty name value.")]
    public void UpdateCategory_EmptyNameValue_DomainExceptionValidation() {
        Category category = new Category(1, "Test");
        Action action = () => category.Update("");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }
    [Fact(DisplayName = "Update Category with null name value.")]
    public void UpdateCategory_NullNameValue_DomainExceptionValidation() {
        Category category = new Category(1, "Test");
        Action action = () => category.Update(null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.");
    }
}