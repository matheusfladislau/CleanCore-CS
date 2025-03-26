using CleanCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCore.Infra.Data.EntityConfiguration; 
public class SupplierConfiguration : IEntityTypeConfiguration<Supplier> {
    public void Configure(EntityTypeBuilder<Supplier> builder) {
        builder.HasKey(k => new { k.Id, k.CNPJ });

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Supplier(1, "Fornecedor 1", "11112222333344"),
            new Supplier(2, "Fornecedor 2", "11112222333344"),
            new Supplier(3, "Fornecedor 3", "11112222333344")
            );
    }
}
