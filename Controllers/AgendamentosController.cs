using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBCORE_Clinica_Medica.Data;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Controllers
{
    [Authorize]
    public class AgendamentosController : Controller
    {
        private readonly Contexto _context;

        public AgendamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Agendamentos
        public async Task<IActionResult> Index(string nome)
        {
            if (!String.IsNullOrEmpty(nome))
            {
                ViewData["FilterByName"] = nome;

                var agendamentos = from agendamento in _context.Agendamentos                                                                         
                                   join medico in _context.Medicos on agendamento.idMedico equals medico.id
                                   join paciente in _context.Pacientes on agendamento.idPaciente equals paciente.id
                                   select new Agendamento
                                   {
                                       id = agendamento.id,
                                       paciente = agendamento.paciente,
                                       medico = agendamento.medico,
                                       dataRealizacao = agendamento.dataRealizacao,
                                       dataAgendamento = agendamento.dataAgendamento,
                                       agendamentoStatus = agendamento.agendamentoStatus
                                   };

                //IQueryable<Agendamento> agendamentos = _context.Agendamentos.Include(a => a.medico).Include(a => a.paciente);
                agendamentos = agendamentos.Where(a => a.paciente.nome.Contains(nome));

                return View(await agendamentos.AsNoTracking().ToListAsync());
            }
            var contexto = _context.Agendamentos.Include(a => a.medico).Include(a => a.paciente);
            return View(await contexto.ToListAsync());
        }

        // GET: Agendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.medico)
                .Include(a => a.paciente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            var tAgendamento = Enum.GetValues(typeof(AgendamentoStatus))
                               .Cast<AgendamentoStatus>()
                               .Select(p => new SelectListItem
                               {
                                    Value = p.ToString(),
                                    Text = p.ToString()
                               });

            ViewBag.tAgendamento = tAgendamento;
            ViewData["idMedico"] = new SelectList(_context.Medicos, "id", "nome");
            ViewData["idPaciente"] = new SelectList(_context.Pacientes, "id", "nome");
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,idPaciente,idMedico,dataRealizacao,dataAgendamento,agendamentoStatus")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idMedico"] = new SelectList(_context.Medicos, "id", "nome", agendamento.idMedico);
            ViewData["idPaciente"] = new SelectList(_context.Pacientes, "id", "nome", agendamento.idPaciente);
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            var tAgendamento = Enum.GetValues(typeof(AgendamentoStatus))
                   .Cast<AgendamentoStatus>()
                   .Select(p => new SelectListItem
                   {
                       Value = p.ToString(),
                       Text = p.ToString()
                   });

            ViewBag.tAgendamento = tAgendamento;
            ViewData["idMedico"] = new SelectList(_context.Medicos, "id", "nome", agendamento.idMedico);
            ViewData["idPaciente"] = new SelectList(_context.Pacientes, "id", "nome", agendamento.idPaciente);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,idPaciente,idMedico,dataRealizacao,dataAgendamento,agendamentoStatus")] Agendamento agendamento)
        {
            if (id != agendamento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idMedico"] = new SelectList(_context.Medicos, "id", "nome", agendamento.idMedico);
            ViewData["idPaciente"] = new SelectList(_context.Pacientes, "id", "nome", agendamento.idPaciente);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.medico)
                .Include(a => a.paciente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamentos.Any(e => e.id == id);
        }
    }
}
