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
    public class PacientesController : Controller
    {
        private readonly Contexto _context;

        public PacientesController(Contexto context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index(string nomeSobrenome)
        {
            if (!String.IsNullOrEmpty(nomeSobrenome))
            {
                ViewData["FilterByName"] = nomeSobrenome;

                var pacientes = from paciente in _context.Pacientes
                              select paciente;

                pacientes = pacientes.Where(p => p.nome.Contains(nomeSobrenome) || p.sobrenome.Contains(nomeSobrenome));

                return View(await pacientes.AsNoTracking().ToListAsync());
            }
            return View(await _context.Pacientes.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,sobrenome,nascimento,sexo,rg,cpf,telres,telcel,email,cep,cidade,estado,endereco,numero,bairro,complemento")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,sobrenome,nascimento,sexo,rg,cpf,telres,telcel,email,cep,cidade,estado,endereco,numero,bairro,complemento")] Paciente paciente)
        {
            if (id != paciente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.id))
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
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.id == id);
        }

        public ActionResult VerificarCPF(string cpf, int id)
        {
            bool cpfExiste = _context.Pacientes.Where(p => p.cpf == cpf && p.id != id).Count() == 0;
            return Json(cpfExiste);
        }
    }
}
