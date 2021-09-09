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
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "Tamanho do campo 'Descrição' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Descrição' é obrigatório.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "Campo 'Preço' é obrigatório.")]
        [Display(Name = "Preço")]
        public double preco { get; set; }
        
        [Range(minimum: 1, maximum: 9999, ErrorMessage = "Tamanho do campo 'Estoque' excedeu o limite.")]
        [Required(ErrorMessage = "Campo 'Estoque' é obrigatório.")]
        [Display(Name = "Estoque")]
        public int estoque { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required]
        [Display(Name = "Total")]
        public double total { get; set; }
    }
}
