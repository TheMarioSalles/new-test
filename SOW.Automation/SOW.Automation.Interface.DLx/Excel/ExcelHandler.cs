using System;
using System.Collections.Generic;
using System.Linq;
using SOW.Automation.Interface.Dlx.Excel.Commands;
using SOW.Automation.Interface.Dlx.Excel.Enums;
using SOW.Automation.Interface.Dlx.Excel.Models;
using SOW.Automation.Interface.Dlx.Excel.Services;

namespace SOW.Automation.Interface.Dlx.Excel
{
	public class ExcelHandler
	{
		public CoordenadasCommandResponse AlocarObjeto(string path, string file, RpaDadosStageInfo rpa)
		{
			try {
				//var path = @"C:\Workspace\";
				//var file = @"Teste.xlsm";
				ExcelReaderHandlerService excel = new ExcelReaderHandlerService(path, file);
				ExcelWriterHandlerService rexcel = new ExcelWriterHandlerService(path, file);
				var lista = excel.CarregaPlanilhaExcel();
				var ee = BlocosGeraisDisponiveisService.DetalhesStagesDisponiveis(lista.ToList(), rpa);
				BlocosGeraisAlocacoesService b = new BlocosGeraisAlocacoesService(ee, rexcel);
				return b.AlocaEspacosStage();
			} catch (Exception) {
				throw;
			}
		}
		
		public IList<CoordenadasCommandResponse> AlocarObjetos(string path, string file, IList<RpaDadosStageInfo> rpas)
		{
			try {
				//var path = @"C:\Workspace\";
				//var file = @"Teste.xlsm";
				ExcelReaderHandlerService excel = new ExcelReaderHandlerService(path, file);
				ExcelWriterHandlerService rexcel = new ExcelWriterHandlerService(path, file);

				var lista = excel.CarregaPlanilhaExcel();
            
				IList<CoordenadasCommandResponse> responses = new List<CoordenadasCommandResponse>();
				foreach (var item in rpas) {
					var ee = BlocosGeraisDisponiveisService.DetalhesStagesDisponiveis(lista.ToList(), item);
					BlocosGeraisAlocacoesService b = new BlocosGeraisAlocacoesService(ee, rexcel);
					responses.Add(b.AlocaEspacosStage());
				}
				/*
				for (int i = 0; i < rpas.Count; i++) {
					RpaDadosStageInfo rpa = new RpaDadosStageInfo {
						Status = EStatusStage.Ready,
						FamiliaDlx = EStatusStageDlx.AMB,
						Ms = "5033682270",
						QtdPalets = 22,
						Sid = "SID0268847"
					};
				}*/
				return responses;
			} catch (Exception) {
				throw;
			}
		}
	}
}
