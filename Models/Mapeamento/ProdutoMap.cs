using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Models.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.descricao).HasMaxLength(50).IsRequired();
            builder.Property(p => p.preco).HasColumnType("money").IsRequired();
            builder.Property(p => p.estoque).HasColumnType("int").IsRequired();
            builder.Property(p => p.total).HasColumnType("money").IsRequired();

            builder.ToTable("Produto");
        }
    }
}
