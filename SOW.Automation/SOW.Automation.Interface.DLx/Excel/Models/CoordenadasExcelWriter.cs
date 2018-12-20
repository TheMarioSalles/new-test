using System.Collections.Generic;

namespace SOW.Automation.Interface.Dlx.Excel.Models
{
    public class CoordenadasExcelWriter
    {
        public bool CoordenadaDisponivel { get; set; }
        public List<CoordenadasExcelWriterDetalhes> Detalhes { get; set; }
        public RpaDadosStageInfo DadosRpa { get; set; }
    }
}
