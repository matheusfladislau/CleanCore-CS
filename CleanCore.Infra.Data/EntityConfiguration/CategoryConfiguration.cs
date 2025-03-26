using CleanCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCore.Infra.Data.EntityConfiguration; 
public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
    public void Configure(EntityTypeBuilder<Category> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Category(1, "Material escolar"),
            new Category(2, "Eletrônicos"),
            new Category(3, "Acessórios")
            );
    }
}
