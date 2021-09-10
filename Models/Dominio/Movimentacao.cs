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
    [Table("Movimentacao")]
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Produto")]
        public Produto produto { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("Produto")]
        public int idProduto { get; set; }

        [Display(Name = "Tipo")]
        [StringLength(7, ErrorMessage = "Tamanho do campo 'Tipo' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Tipo' é obrigatório.")]
        public string tipo { get; set; }

        [Range(minimum: 1, maximum: 99999, ErrorMessage = "Tamanho do campo 'Quantidade' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Quantidade' é obrigatório")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }
    }
}
