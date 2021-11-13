using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Models.Mapeamento
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.idPaciente).IsRequired();
            builder.Property(p => p.idMedico).IsRequired();
            builder.Property(p => p.dataRealizacao).HasColumnType("date").IsRequired();
            builder.Property(p => p.dataAgendamento).HasColumnType("date").IsRequired();
            builder.Property(p => p.agendamentoStatus).IsRequired();
            builder.HasOne(p => p.paciente).WithMany(p => p.agendamentos).HasForeignKey(p => p.idPaciente).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.medico).WithMany(p => p.agendamentos).HasForeignKey(p => p.idMedico).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Agendamento");
        }
    }
}
