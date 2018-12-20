using SOW.Automation.Interface.Dlx.Excel.Commands;
using SOW.Automation.Interface.Dlx.Excel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOW.Automation.Interface.Dlx.Excel.Services
{
    public class BlocosGeraisAlocacoesService
    {
        CoordenadasExcelWriter _coordenadasExcel;
        ExcelWriterHandlerService _exl;

        public BlocosGeraisAlocacoesService(CoordenadasExcelWriter coordenadasExcel, ExcelWriterHandlerService exl)
        {
            _coordenadasExcel = coordenadasExcel;
            _exl = exl;
        }

        public CoordenadasCommandResponse AlocaEspacosStage()
        {
            if (_coordenadasExcel.CoordenadaDisponivel)
            {
                string stage = _exl.PopulaPlanilhaExcel(_coordenadasExcel);
                return new CoordenadasCommandResponse() { CoordenadaDisponivel = true, Alocado = true,  RpaDadosStageInfo = _coordenadasExcel.DadosRpa, Stage = stage };
            }
            else
            {
                return new CoordenadasCommandResponse() { CoordenadaDisponivel = false, Alocado = false, RpaDadosStageInfo = _coordenadasExcel.DadosRpa, Stage = "" };
            }
        }

    }
}
