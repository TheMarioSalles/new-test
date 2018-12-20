using System.Collections.Generic;
using SOW.Automation.Interface.Dlx.Models;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.Dlx.Windows
{
	public class ShipmentAllocationOperations : WindowBase
	{
		public ShipmentAllocationOperations(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoExit()
		{
			this.PointAndClick(1750, 115);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFind()
		{
			this.PointAndClick(1835, 115);
			this.Wait(1000);
		}
		
		public void ClicarBotaoLocate()
		{
			this.PointAndClick(220, 60);
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
		
		public void ClicarCampoCarrierMoveID()
		{
			this.PointAndClick(812, 222);
			this.Wait(1000);
		}
		
		public void ClicarRotuloResultadoFiltro(int option)
		{
			int positionY = 120 + (20 * option);
			this.PointAndClick(240, positionY);
			this.Wait(1000);
		}
		
		public void InitializeWindow(string msValue, bool click)
		{
			
		}

		public void PreencherCampoCarrierMoveID(string value)
		{
			this.PressionarTecla(SOW.Automation.Common.KeyboardEnum.BACKSPACE);
			this.InserirTexto(value);
			this.Wait(1000);
		}
		
		public void PreencherCampoFiltro(string value)
		{
			this.InserirTexto(value);
			this.Wait(500);
		}
	}
}
