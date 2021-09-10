using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Models.Mapeamento
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.idProduto).IsRequired();
            builder.Property(p => p.tipo).HasMaxLength(7).IsRequired();
            builder.Property(p => p.quantidade).HasColumnType("int").IsRequired();

            builder.ToTable("Movimentacao");
        }
    }
}
