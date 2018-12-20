using System.Collections.Generic;
using SOW.Automation.Interface.Dlx.Models;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.Dlx.Windows
{
	public class OrderInformation : WindowBase
	{
		public OrderInformation(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public bool ChecarJanela()
		{
			return this.ChecarJanela(@"\OCR\OrderInformationTitle.png");
		}
		
		public void ClicarBotaoAllocate()
		{
			this.Wait(1000);
			this.PointAndClick(640, 990);
			this.Wait(1000);
		}
		
		public void ClicarBotaoExit()
		{
			this.Wait(1000);
			this.PointAndClick(1785, 115);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFind()
		{
			this.Wait(1000);
			this.PointAndClick(1550, 115);
			this.Wait(1000);
		}
		
		public void ClicarBotaoHome()
		{
			this.Wait(1000);
			this.PointAndClick(1835, 115);
			this.Wait(1000);
		}
		
		public void ClicarBotaoLocate()
		{
			this.PointAndClick(220, 60);
			this.Wait(500);
		}
		
		public void ClicarCampoFiltro()
		{
			this.PointAndClick(300, 105);
			this.Wait(500);
		}
		
		public void ClicarBotaoFiltroGo()
		{
			this.PointAndClick(390, 105);
			this.Wait(500);
		}
		
		public void ClicarBotaoFiltroOk()
		{
			this.PointAndClick(330, 280);
			this.Wait(500);
		}
		
		public void ClicarRotuloResultadoFiltro(int option)
		{
			int positionY = 120 + (20 * option);
			this.PointAndClick(240, positionY);
			this.Wait(500);
		}

		public void ClicarTabelaListagemAgendamentos(int option)
		{
			this.Wait(500);
			int positionY = 168 + (20 * option);
			this.PointAndClick(325, positionY);
			this.Wait(500);
		}
		
		public void InitializeWindow()
		{
			
		}
		
		public void PreencherCampoFiltro(string value)
		{
			this.InserirTexto(value);
			this.Wait(500);
		}

		public void SelecionarTodosItensTabelaListagemAgendamentos()
		{
			ClicarTabelaListagemAgendamentos(1);
			this.SegurarTecla(SOW.Automation.Common.KeyboardEnum.SHIFT);
			ClicarTabelaListagemAgendamentos(2);
			this.LiberarTecla(SOW.Automation.Common.KeyboardEnum.SHIFT);
			this.Wait(1000);
		}
	}
}
