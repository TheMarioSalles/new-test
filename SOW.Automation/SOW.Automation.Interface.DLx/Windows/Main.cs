using System.Threading;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.Dlx.Windows
{
	public class Main : WindowBase
	{
		public Main(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoLocate()
		{
			this.PointAndClick(220, 60);
			this.Wait(1000);
		}
		
		public void ClicarCabecalho()
		{
			this.PointAndClick(750, 190);
			this.Wait(1000);
		}
		
		public void ClicarCampoFiltro()
		{
			this.PointAndClick(300, 105);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFiltroGo()
		{
			this.PointAndClick(390, 105);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFiltroOk()
		{
			this.PointAndClick(330, 280);
			this.Wait(1000);
		}
		
		public void ClicarRotuloResultadoFiltro(int option)
		{
			int positionY = 120 + (20 * option);
			this.PointAndClick(240, positionY);
			this.Wait(1000);
		}
		
		public void InitializeWindow()
		{
			while (!this.DeskAutomationService.BaseElement.WindowExists("E²e™ - Consumer Driven Optimization - \\\\Remote", 0)) {
				this.Wait(1000);
			}
			this.AbrirJanela();
			this.SelecionarJanela();
			if (!this.ChecarJanela(@"\OCR\MainLeftPanel.png"))
				this.FecharJanela();
			else {
				this.SelecionarJanela();
				ClicarCabecalho();
				this.MaximizarJanela();
				ClicarBotaoLocate();
				ClicarCampoFiltro();
				PreencherCampoFiltro("tarefas");
				ClicarBotaoFiltroGo();
				ClicarRotuloResultadoFiltro(1);
				ClicarBotaoFiltroOk();
			}
		}
		
		public void PreencherCampoFiltro(string value)
		{
			this.InserirTexto(value);
			this.Wait(1000);
		}
	}
}
