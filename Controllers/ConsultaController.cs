using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Extra;
using WEBCORE_Clinica_Medica.Data;
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
                                              crm = agendamento.medico.crm,
                                              dataRealizacao = agendamento.dataRealizacao,
                                              dataAgendamento = agendamento.dataAgendamento,
                                              status = Enum.GetName(typeof(AgendamentoStatus), agendamento.agendamentoStatus)
                                          };
            return View(lista);
        }

        public IActionResult TotalMovimentacoes()
        {
            IEnumerable<TotalMovimentacoes> lista = from movimentacao in contexto.Movimentacoes
                                                  .Include(p => p.produto)
                                                  .ToList()
                                                  group movimentacao by new { movimentacao.produto.descricao, movimentacao.movTipo }
                                                  into grupo
                                                  orderby grupo.Key.descricao, grupo.Key.movTipo
                                                  select new TotalMovimentacoes
                                                  {
                                                      descProduto = grupo.Key.descricao,
                                                      tipoMovimentacao = Enum.GetName(typeof(MovimentacaoTipo), grupo.Key.movTipo),
                                                      totalMovimentacoes = grupo.Count(),
                                                      totalProdutos = grupo.Sum(p => p.quantidade)
                                                  };
            return View(lista);
        }

        public IActionResult PivotMovimentacoes()
        {
            IEnumerable<TotalMovimentacoesPivot> listaProdutoMovimentacoes = from movimentacao in contexto.Movimentacoes
                                                  .Include(p => p.produto)
                                                  .ToList()
                                                                               group movimentacao by new { movimentacao.produto.descricao, movimentacao.movTipo }
                                                  into grupo
                                                                               orderby grupo.Key.descricao, grupo.Key.movTipo
                                                                               select new TotalMovimentacoesPivot
                                                                               {
                                                                                   descProduto = grupo.Key.descricao,
                                                                                   tipoMovimentacao = Enum.GetName(typeof(MovimentacaoTipo), grupo.Key.movTipo),
                                                                                   valorTotal = grupo.Sum(p => p.quantidade * p.produto.preco)
                                                                               };

            var PivotTableMovimentacoes = listaProdutoMovimentacoes.ToList().ToPivotTable(
                                                                        pivot => pivot.tipoMovimentacao,
                                                                        pivot => pivot.descProduto,
                                                                        pivot => pivot.Any() ? pivot.Sum(x => x.valorTotal) : 0
                                                                    );

            List<PivotMovimentacoes> listaPivot = new List<PivotMovimentacoes>();
            
            listaPivot = (from DataRow coluna in PivotTableMovimentacoes.Rows
                    select new PivotMovimentacoes()
                    {
                        produto = coluna[0].ToString(),
                        entrada = Convert.ToSingle(coluna[1]),
                        saida = Convert.ToSingle(coluna[2]),
                    }).ToList();
            return View(listaPivot);
        }
    }
}
