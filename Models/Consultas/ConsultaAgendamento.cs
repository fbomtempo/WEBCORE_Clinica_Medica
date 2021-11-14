using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_Clinica_Medica.Models.Consultas
{
    public class ConsultaAgendamento
    {
        public int id { get; set; }

        [Display(Name = "Paciente")]
        public string paciente { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Nascimento")]
        public DateTime nascimento { get; set; }

        [Display(Name = "Médico")]
        public string medico { get; set; }

        [Display(Name = "Especialidade")]
        public string especialidade { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Atendimento")]
        public DateTime dataAtendimento { get; set; }

        [Display(Name = "Situação")]
        public string status { get; set; }
    }
}
