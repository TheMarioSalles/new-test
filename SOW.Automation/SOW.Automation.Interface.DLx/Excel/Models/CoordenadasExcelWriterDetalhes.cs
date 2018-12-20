using System.Collections.Generic;

namespace SOW.Automation.Interface.Dlx.Excel.Models
{
    public class CoordenadasExcelWriterDetalhes
    {
        public CoordenadasExcelWriterDetalhes()
        {
            Colunas = new List<int>();
        }
        public int PolicaoLinha { get; set; }
        public List<int> Colunas { get; set; }
        public int QtdPalets { get; set; }
    }
}
