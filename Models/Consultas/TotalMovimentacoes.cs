using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_Clinica_Medica.Models.Consultas
{
    public class TotalMovimentacoes
    {
        public int id { get; set; }

        [Display(Name = "Tipo")]
        public string tipoMovimentacao { get; set; }

        [Display(Name = "Total de movimentações")]
        public int totalMovimentacoes { get; set; }

        [Display(Name = "Total de produtos")]
        public int totalProdutos { get; set; }
    }
}
