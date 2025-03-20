using CleanCore.Domain.Validation;
using System.Collections.Generic;

namespace CleanCore.Domain.Entities;

public sealed class Category : Entity {

    public Category(string name) {
        ValidateName(name);

        this.Name = name;
    }

    public Category(int id, string name) {
        ValidateId(id);
        ValidateName(name);

        this.Id = id;
        this.Name = name;
    }


    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public void Update(string name) {
        ValidateName(name);

        this.Name = name;
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

}
