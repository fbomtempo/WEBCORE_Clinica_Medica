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
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PacienteMap());
            builder.ApplyConfiguration(new MedicoMap());
            builder.ApplyConfiguration(new FuncionarioMap());
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new MovimentacaoMap());
            builder.ApplyConfiguration(new AgendamentoMap());
        }
    }
}
