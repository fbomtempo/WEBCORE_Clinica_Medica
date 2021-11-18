using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Models;
using WEBCORE_Clinica_Medica.Models.Consultas;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Controllers
{
    [Authorize]
    public class ConsultaController : Controller
    {

        private readonly Contexto contexto;

        public ConsultaController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult ListarPacienteAgendamento()
        {
            IEnumerable<ConsultaAgendamento> lista = from agendamento in contexto.Agendamentos
                                          .Include(p => p.paciente)
                                          .Include(m => m.medico)
                                          .ToList()
                                          select new ConsultaAgendamento
                                          {
                                              id = agendamento.id,
                                              paciente = agendamento.paciente.nome + " " + agendamento.paciente.sobrenome,
                                              nascimento = agendamento.paciente.nascimento,
                                              medico = agendamento.medico.nome + " " + agendamento.medico.sobrenome,
                                              especialidade = agendamento.medico.especialidade,
                                              dataAtendimento = agendamento.dataAgendamento,
                                              status = Enum.GetName(typeof(AgendamentoStatus), agendamento.agendamentoStatus)
                                          };
            return View(lista);
        }

        [HttpGet("/Consulta/TotalMovimentacoes")]
        public IActionResult TotalMovimentacoes()
        {
            IEnumerable<TotalMovimentacoes> lista = from movimentacao in contexto.Movimentacoes                                      
                                                  .ToList()
                                                  group movimentacao by new { movimentacao.movTipo }
                                                  into grupo
                                                  orderby grupo.Key.movTipo
                                                  select new TotalMovimentacoes
                                                  {
                                                      tipoMovimentacao = Enum.GetName(typeof(MovimentacaoTipo), grupo.Key.movTipo),
                                                      totalMovimentacoes = grupo.Count(),
                                                      totalProdutos = grupo.Sum(p => p.quantidade)
                                                  };
            return View(lista);
        }
    }
}
