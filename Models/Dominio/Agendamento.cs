using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_Clinica_Medica.Models.Dominio
{
    public enum AgendamentoStatus { Agendado, Atendido, Cancelado }

    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Paciente")]
        public Paciente paciente { get; set; }

        [Display(Name = "Paciente")]
        [ForeignKey("Produto")]
        public int idPaciente { get; set; }

        [Display(Name = "Médico")]
        public Medico medico { get; set; }

        [Display(Name = "Médico")]
        [ForeignKey("Medico")]
        public int idMedico { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo 'Data Realização' é obrigatório")]
        [Display(Name = "Data Realização")]
        public DateTime dataRealizacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo 'Data Agendada' é obrigatório")]
        [Display(Name = "Data Agendada")]
        public DateTime dataAgendamento { get; set; }

        [Display(Name = "Situação")]
        [Required(ErrorMessage = "Campo 'Situação' é obrigatório.")]
        public AgendamentoStatus agendamentoStatus { get; set; }
    }
}
