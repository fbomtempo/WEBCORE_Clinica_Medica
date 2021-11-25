using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_Clinica_Medica.Models.Consultas
{
    public class TotalMovimentacoesPivot
    {
        public int id { get; set; }
        public string descProduto { get; set; }
        public string tipoMovimentacao { get; set; }
        public int totalMovimentacoes { get; set; }
        public double valorTotal { get; set; }
    }
}
