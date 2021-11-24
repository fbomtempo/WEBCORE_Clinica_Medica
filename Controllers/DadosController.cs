using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_Clinica_Medica.Data;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Controllers
{
    [Authorize]
    public class DadosController : Controller
    {
        private readonly CultureInfo cultura = CultureInfo.CreateSpecificCulture("pt-BR");

        private readonly Contexto contexto;

        public DadosController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult GerarPacientes()
        {
            Random randNum = new Random();

            string[] nomesMasculinos = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo" };
            string[] nomesFemininos = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza" };
            string[] sobrenomes = { "Silva", "Santos", "Oliveira", "Souza", "Rodrigues", "Ferreira", "Alves", "Pereira", "Lima", "Gomes" };
            string[] municipios = { "Assis", "Cândido Mota", "Tarumã", "Presidente Prudente", "Palmital", "Pedrinhas Paulista", "Maracaí", "Cruzália" };
            string[] dominios = { "outlook", "hotmail", "gmail", "uol", "globo", "yahoo" };

            for (int i = 0; i < 20; i++)
            {
                Paciente paciente = new Paciente();

                paciente.nome = (i % 2 == 0) ? nomesMasculinos[i / 2] : nomesFemininos[i / 2];
                paciente.sobrenome = sobrenomes[i / 2];
                paciente.nascimento = DateTime.Parse(randNum.Next(1, 30).ToString().PadLeft(2, '0') + "/" + randNum.Next(1, 12).ToString().PadLeft(2, '0') + "/" + randNum.Next(1960, 2010).ToString(), cultura);
                paciente.sexo = (i % 2 == 0) ? "Masculino" : "Feminino";
                paciente.rg = randNum.Next(1, 99).ToString().PadLeft(2, '0') + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(1, 9).ToString();
                paciente.cpf = randNum.Next(1, 999).ToString().PadLeft(3, '0') + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(2, 99).ToString().PadLeft(2, '0');
                paciente.telres = "(18) " + randNum.Next(1, 9999).ToString().PadLeft(4, '0') + "-" +  randNum.Next(1, 9999).ToString().PadLeft(4, '0');
                paciente.telcel = "(18) " + randNum.Next(1, 99999).ToString().PadLeft(5, '0') + "-" + randNum.Next(1, 9999).ToString().PadLeft(4, '0');
                paciente.email = paciente.nome.ToLower() + "@" + dominios[randNum.Next() % 6].ToLower() + ".com.br";
                paciente.cep = "19000-000";
                paciente.cidade = municipios[randNum.Next() % 8];
                paciente.estado = "SP";
                paciente.endereco = "Rua " + randNum.Next(1, 20).ToString();
                paciente.numero = (i + 1) * 10;
                paciente.bairro = "Bairro " + randNum.Next(1, 20).ToString();

                contexto.Pacientes.Add(paciente);
            }

            contexto.SaveChanges();

            return View(contexto.Pacientes.OrderBy(o => o.nome).ToList());
        }

        public IActionResult GerarMedicos()
        {
            Random randNum = new Random();

            string[] nomesMasculinos = { "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Henrique", "Gustavo" };
            string[] nomesFemininos = { "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Lara", "Isadora", "Mariana" };
            string[] sobrenomes = { "Costa", "Ribeiro", "Martins", "Carvalho", "Almeida", "Lopes", "Soares", "Fernandes", "Vieira", "Barbosa" };
            string[] especialidades = { "Cargiologista", "Ortopedista", "Desmatologista", "Oftalmologista", "Neurologista" };
            string[] municipios = { "Assis", "Cândido Mota", "Tarumã", "Presidente Prudente", "Palmital", "Pedrinhas Paulista", "Maracaí", "Cruzália" };
            string[] dominios = { "outlook", "hotmail", "gmail", "uol", "globo", "yahoo" };

            for (int i = 0; i < 20; i++)
            {
                Medico medico = new Medico();

                medico.nome = (i % 2 == 0) ? nomesMasculinos[i / 2] : nomesFemininos[i / 2];
                medico.sobrenome = sobrenomes[i / 2];
                medico.nascimento = DateTime.Parse(randNum.Next(1, 30).ToString() + "/" + randNum.Next(1, 12).ToString() + "/" + randNum.Next(1960, 2003).ToString(), cultura);
                medico.sexo = (i % 2 == 0) ? "Masculino" : "Feminino";
                medico.crm = "00000000";
                medico.especialidade = especialidades[randNum.Next() % 5]; ;
                medico.rg = randNum.Next(1, 99).ToString().PadLeft(2, '0') + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(1, 9).ToString();
                medico.cpf = randNum.Next(1, 999).ToString().PadLeft(3, '0') + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(1, 99).ToString().PadLeft(2, '0');
                medico.telres = "(18) " + randNum.Next(1, 9999).ToString().PadLeft(4, '0') + "-" + randNum.Next(1, 9999).ToString().PadLeft(4, '0');
                medico.telcel = "(18) " + randNum.Next(1, 99999).ToString().PadLeft(5, '0') + "-" + randNum.Next(1, 9999).ToString().PadLeft(4, '0');
                medico.email = medico.nome.ToLower() + "@" + dominios[randNum.Next() % 6].ToLower() + ".com.br";
                medico.cep = "19000-000";
                medico.cidade = municipios[randNum.Next() % 8];
                medico.estado = "SP";
                medico.endereco = "Rua " + randNum.Next(1, 20).ToString();
                medico.numero = (i + 1) * 10;
                medico.bairro = "Bairro " + randNum.Next(1, 20).ToString();

                contexto.Medicos.Add(medico);
            }

            contexto.SaveChanges();

            return View(contexto.Medicos.OrderBy(o => o.nome).ToList());
        }

        public IActionResult GerarFuncionarios()
        {
            Random randNum = new Random();

            string[] nomesMasculinos = { "Murilo", "Pedro Henrique", "Pietro", "Felipe", "Isaac", "Daniel", "Anthony", "Leonardo", "Eduardo", "Victor" };
            string[] nomesFemininos = { "Ana Júlia", "Ana Clara", "Elisa", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lvínia", "Esther", "Sarah" };
            string[] sobrenomes = { "Rocha", "Dias", "Nascimento", "Andrade", "Moreira", "Nunes", "Marques", "Machado", "Freitas", "Cardoso" };
            string[] cargos = { "Secretário", "Assistente Administrativo", "Analista de Sistema" };
            string[] municipios = { "Assis", "Cândido Mota", "Tarumã", "Presidente Prudente", "Palmital", "Pedrinhas Paulista", "Maracaí", "Cruzália" };
            string[] dominios = { "outlook", "hotmail", "gmail", "uol", "globo", "yahoo" };

            for (int i = 0; i < 20; i++)
            {
                Funcionario funcionario = new Funcionario();

                funcionario.nome = (i % 2 == 0) ? nomesMasculinos[i / 2] : nomesFemininos[i / 2];
                funcionario.sobrenome = sobrenomes[i / 2];
                funcionario.nascimento = DateTime.Parse(randNum.Next(1, 30).ToString() + "/" + randNum.Next(1, 12).ToString() + "/" + randNum.Next(1960, 2003).ToString(), cultura);
                funcionario.sexo = (i % 2 == 0) ? "Masculino" : "Feminino";
                funcionario.cargo = cargos[randNum.Next() % 3];
                funcionario.rg = randNum.Next(1, 99).ToString().PadLeft(2, '0') + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(1, 9).ToString();
                funcionario.cpf = randNum.Next(1, 999).ToString().PadLeft(3, '0') + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(1, 99).ToString().PadLeft(2, '0');
                funcionario.telres = "(18) " + randNum.Next(1, 9999).ToString().PadLeft(4, '0') + "-" + randNum.Next(1, 9999).ToString().PadLeft(4, '0');
                funcionario.telcel = "(18) " + randNum.Next(1, 99999).ToString().PadLeft(5, '0') + "-" + randNum.Next(1, 9999).ToString().PadLeft(4, '0');
                funcionario.email = funcionario.nome.ToLower() + "@" + dominios[randNum.Next() % 6].ToLower() + ".com.br";
                funcionario.cep = "19000-000";
                funcionario.cidade = municipios[randNum.Next() % 8];
                funcionario.estado = "SP";
                funcionario.endereco = "Rua " + randNum.Next(1, 20).ToString();
                funcionario.numero = (i + 1) * 10;
                funcionario.bairro = "Bairro " + randNum.Next(1, 20).ToString();

                contexto.Funcionarios.Add(funcionario);
            }

            contexto.SaveChanges();

            return View(contexto.Funcionarios.OrderBy(o => o.nome).ToList());
        }

        public IActionResult GerarProdutos()
        {
            Random randNum = new Random();

            for (int i = 0; i < 20; i++)
            {
                Produto produto = new Produto();

                produto.descricao = "Produto " + (i + 1).ToString();
                produto.preco = randNum.NextDouble() * 10;
                produto.estoque = randNum.Next() % 50;
                produto.total = produto.preco * produto.estoque;

                contexto.Produtos.Add(produto);
            }

            contexto.SaveChanges();

            return View(contexto.Produtos.OrderBy(o => o.descricao).ToList());
        }
    }
}
