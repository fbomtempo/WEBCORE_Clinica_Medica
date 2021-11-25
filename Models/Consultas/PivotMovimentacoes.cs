using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_Clinica_Medica.Models.Consultas
{
    public class PivotMovimentacoes
    {
        public int id { get; set; }

        [Display(Name = "Produto")]
        public string produto { get; set; }

        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        [Display(Name = "Entrada")]
        public double entrada { get; set; }

        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        [Display(Name = "Saída")]
        public double saida { get; set; }
    }
}
