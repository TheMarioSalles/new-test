using SOW.Automation.Interface.Dlx.Excel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Dlx.Excel.Commands
{
	public class CoordenadasCommandResponse
	{
		public bool CoordenadaDisponivel { get; set; }
		public bool Alocado { get; set; }
		public RpaDadosStageInfo RpaDadosStageInfo { get; set; }
		public string Stage { get; set; }
	}
}