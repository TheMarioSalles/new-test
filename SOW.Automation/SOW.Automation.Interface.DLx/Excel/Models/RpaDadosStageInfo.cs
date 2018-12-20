using SOW.Automation.Interface.Dlx.Excel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Dlx.Excel.Models
{
    public class RpaDadosStageInfo
    {
        public string Ms { get; set; }
        public string Sid { get; set; }
        public EStatusStage Status { get; set; }
        public string Stage { get; set; }
        public int QtdPalets { get; set; }
        public EStatusStageDlx FamiliaDlx { get; set; }
    }
}
