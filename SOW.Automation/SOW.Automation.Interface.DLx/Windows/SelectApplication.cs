using System.Threading;
using Sikuli4Net.sikuli_REST;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.Dlx.Windows
{
	public class SelectApplication : WindowBase
	{
		public SelectApplication(WebService webService, DesktopService desktopService, OCRService ocrService) : base(webService, desktopService, ocrService) { }
		
		public void ClicarBotaoCancel() 
		{
			this.PointAndClick(1100, 700);
		}
		
		public void ClicarBotaoOk() 
		{
			this.PointAndClick(1000, 700);
		}
		
		public void InitializeWindow ()
		{
			while (!this.DeskAutomationService.BaseElement.WindowExists("E²e™ - Consumer Driven Optimization - \\\\Remote", 0)) {
				this.Wait(1000);
			}
			this.AbrirJanela("E²e™ - Consumer Driven Optimization - \\\\Remote");
			this.PointAndClick(1050, 525);
			this.SelecionarJanela();
			if (!this.ChecarJanela(@"\OCR\SelectApplicationLogo.png"))
			{
				Console.WriteLine("Not Found");
				this.FecharJanela();
			}
			else
			{
				PreencherConnectionName();
				ClicarBotaoOk();
			}
		}
		
		public void PreencherConnectionName() 
		{
			this.PointAndClick(1050, 525);
			this.Wait(1000);
			this.InserirTexto("MMMMMMM");
			this.Wait(1000);
			this.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
			this.Wait(1000);
		}
		
		public void SelecionarConnectionName() 
		{
			this.PointAndClick(1050, 525);
			this.Wait(1000);
		}
		
		public void SelecionarHostName() 
		{
		
		}
		
		public void SelecionarPortNumber() 
		{
			
		}
	}
}
