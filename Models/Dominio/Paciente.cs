using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_Clinica_Medica.Models.Dominio
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="ID")]
        public int id { get; set; }
        
        [StringLength(30, ErrorMessage = "Tamanho do campo 'Nome' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Nome' é obrigatório.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [StringLength(30, ErrorMessage = "Tamanho do campo 'Sobrenome' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Sobrenome' é obrigatório.")]
        [Display(Name = "Sobrenome")]
        public string sobrenome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo 'Nascimento' é obrigatório.")]
        [Display(Name = "Nascimento")]
        public DateTime nascimento { get; set; }

        [StringLength(9, ErrorMessage = "Tamanho do campo 'Sexo' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Sexo' é obrigatório.")]
        [Display(Name = "Sexo")]
        public string sexo { get; set; }

        [StringLength(12, ErrorMessage = "Tamanho do campo 'RG' excedeu o limite")]
        [Required(ErrorMessage = "Campo 'RG' é obrigatório")]
        [Display(Name = "RG")]
        public string rg { get; set; }

        [StringLength(14, ErrorMessage = "Tamanho do campo 'CPF' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'CPF' é obrigatório.")]
        [Remote("VerificarCPF", "Pacientes", ErrorMessage = "CPF já cadastrado.")]
        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [StringLength(14, ErrorMessage = "Tamanho do campo 'Telefone Residencial' excedeu o limite.")]
        [Display(Name = "Telefone Residencial")]
        public string telres { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho do campo 'Telefone Celular' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Telefone Celular' é obrigatório.")]
        [Display(Name = "Telefone Celular")]
        public string telcel { get; set; }

        [StringLength(35, ErrorMessage = "Tamanho do campo 'E-Mail' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'E-Mail' é obrigatório")]
        [RegularExpression("^[a-zA-Z0-9_+-]+[a-zA-Z0-9._+-]*[a-zA-Z0-9_+-]+@[a-zA-Z0-9_+-]+[a-zA-Z0-9._+-]*[.]{1,1}[a-zA-Z]{2,}$", ErrorMessage = "E-Mail invalido.")]
        [Display(Name = "E-Mail")]
        public string email { get; set; }

        [StringLength(9, ErrorMessage = "Tamanho do campo 'CEP' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'CEP' é obrigatório")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [StringLength(50, ErrorMessage = "Tamanho do campo 'Cidade' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Cidade' é obrigatório.")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [StringLength(2, ErrorMessage = "Tamanho do campo 'Estado' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Estado' é obrigatório.")]
        [Display(Name = "Estado")]
        public string estado { get; set; }

        [StringLength(50, ErrorMessage = "Tamanho do campo 'Endereço' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Endereço' é obrigatório.")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Range(minimum: 1, maximum: 9999, ErrorMessage = "Tamanho do campo 'Número' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Número' é obrigatório.")]
        [Display(Name = "Número")]
        public int numero { get; set; }

        [StringLength(30, ErrorMessage = "Tamanho do campo 'Bairro' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Bairro' é obrigatório.")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [StringLength(70, ErrorMessage = "Tamanho do campo 'Complemento' excedeu o limite.")]
        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        public ICollection<Agendamento> agendamentos { get; set; }
    }
}
