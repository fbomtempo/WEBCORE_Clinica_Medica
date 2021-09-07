using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Models.Dominio;
using WEBCORE_Clinica_Medica.Models.Mapeamento;

namespace WEBCORE_Clinica_Medica.Models
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PacienteMap());
        }
    }
}
