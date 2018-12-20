using System.Threading;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.Dlx.Windows
{
	public class LoginRedPrairie : WindowBase
	{
		public LoginRedPrairie(WebService webService, DesktopService desktopService, OCRService ocrService) : base(webService, desktopService, ocrService) { }
		
		public void InitializeWindow()
		{
			if (!this.ChecarJanela(@"\OCR\LoginRedPrairieLogo.png"))
				this.FecharJanela();
			else
			{
				this.Wait(10000);
				this.SelecionarJanela();
				PreencherCampoUserID();
				PreencherCampoPassword();
				ClicarBotaoOk();
			}
		}
		
		public void ClicarBotaoCancel()
		{
			this.PointAndClick(1100, 700);
			this.Wait(1000);
		}
		
		public void ClicarBotaoOk()
		{
			this.PointAndClick(1000, 700);
			this.Wait(1000);
		}
		
		public void PreencherCampoPassword()
		{
			this.PointAndClick(1000, 585);
			this.Wait(1000);
			this.InserirTexto("dhl123");
			this.Wait(1000);
		}
		
		public void PreencherCampoUserID()
		{
			this.PointAndClick(1000, 550);
			this.Wait(1000);
			this.InserirTexto("RPA01");
			this.Wait(1000);
		}
	}
}
