using CleanCore.Domain.Validation;
using System.Collections.Generic;

namespace CleanCore.Domain.Entities;

public sealed class Supplier : Entity {
    public Supplier(int id, string name, string cnpj) {
        ValidateId(id);
        ValidateName(name);
        ValidateCNPJ(cnpj);
        
        this.Id = id;
        this.Name = name;
        this.CNPJ = cnpj;
    }

    public Supplier(string name, string cnpj) {
        ValidateName(name);
        ValidateCNPJ(cnpj);
        
        this.Name = name;
        this.CNPJ = cnpj;
    }


    public string Name { get; private set; }
    public string CNPJ { get; private set; }

    public ICollection<Product> Products { get; set; }


    public void Update(string name, string cnpj) {
        ValidateName(name);
        ValidateCNPJ(cnpj);
        
        this.Name = name;
        this.CNPJ = cnpj;
    }

    private void ValidateId(int id) {
        DomainExceptionValidation.When(id < 0,
                "Invalid id.");
    }

    private void ValidateName(string name) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.");
    }

    private void ValidateCNPJ(string cnpj) {
        DomainExceptionValidation.When(string.IsNullOrEmpty(cnpj),
                "Invalid CNPJ.");

        DomainExceptionValidation.When(cnpj.Length != 14,
                "Invalid. A CNPJ has 14 digits.");
    }
}
