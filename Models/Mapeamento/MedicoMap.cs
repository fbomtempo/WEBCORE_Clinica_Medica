using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Models.Mapeamento
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.nome).HasMaxLength(30).IsRequired();
            builder.Property(p => p.sobrenome).HasMaxLength(30).IsRequired();
            builder.Property(p => p.nascimento).HasColumnType("date").IsRequired();
            builder.Property(p => p.sexo).HasMaxLength(9).IsRequired();
            builder.Property(p => p.crm).HasMaxLength(8).IsRequired();
            builder.Property(p => p.especialidade).HasMaxLength(30).IsRequired();
            builder.Property(p => p.rg).HasMaxLength(12).IsRequired();
            builder.Property(p => p.cpf).HasMaxLength(14).IsRequired();
            builder.HasIndex(p => p.cpf).IsUnique();
            builder.Property(p => p.telres).HasMaxLength(14);
            builder.Property(p => p.telcel).HasMaxLength(15).IsRequired();
            builder.Property(p => p.email).HasMaxLength(35).IsRequired();
            builder.Property(p => p.cep).HasMaxLength(9).IsRequired();
            builder.Property(p => p.cidade).HasMaxLength(50).IsRequired();
            builder.Property(p => p.estado).HasMaxLength(2).IsRequired();
            builder.Property(p => p.endereco).HasMaxLength(50).IsRequired();
            builder.Property(p => p.numero).HasColumnType("int").IsRequired();
            builder.Property(p => p.bairro).HasMaxLength(30).IsRequired();
            builder.Property(p => p.complemento).HasMaxLength(70);

            builder.ToTable("Medico");
        }
    }
}
