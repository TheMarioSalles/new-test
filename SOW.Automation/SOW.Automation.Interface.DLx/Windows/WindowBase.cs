using Sikuli4Net.sikuli_REST;
using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.OCR;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.Dlx.Windows
{
	public class WindowBase
	{
		public WebService WebAutomationService { get; set; }
		public DesktopService DeskAutomationService { get; set; }
		public OCRService OCRAutomationService { get; set; }

		public WindowBase(WebService webService, DesktopService desktopService, OCRService ocrService)
		{
			this.WebAutomationService = webService;
			this.DeskAutomationService = desktopService;
			this.OCRAutomationService = ocrService;
		}
		
		public bool ChecarJanela(string path)
		{
			return this.OCRAutomationService.BaseElement.CheckPattern(new Pattern(String.Concat(Environment.CurrentDirectory, path)), this.OCRAutomationService.DriverContextInfo.Timeout);
		}
		
		public void AbrirJanela()
		{
			this.DeskAutomationService.BaseElement.OpenDesktopInstance("E²e™ - Consumer Driven Optimization - \\\\Remote", this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void AbrirJanela(string title)
		{
			this.DeskAutomationService.BaseElement.OpenDesktopInstance(title, this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void Wait(int miliseconds)
		{
			this.DeskAutomationService.BaseElement.Wait(miliseconds, this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void ClicarDireitoMouse()
		{
			this.DeskAutomationService.BaseElement.MouseRightClick(this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void ClicarEsquerdoMouse()
		{
			this.DeskAutomationService.BaseElement.MouseClick(this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void FecharAplicacao()
		{
			Wait(1000);
			PointAndClick(1900, 5);
			Wait(1000);
			PointAndClick(885, 595);
			if (!this.OCRAutomationService.BaseElement.CheckPattern(new Pattern(@"\OCR\MainCloseButton2.png"), this.OCRAutomationService.DriverContextInfo.Timeout)) {
				//this.OCRAutomationService.BaseElement.ClickPattern(new Pattern(@"\OCR\MainCloseButton2.png"), this.OCRAutomationService.DriverContextInfo.Timeout);
			}
		}
		
		public void FecharJanela()
		{
			this.DeskAutomationService.BaseElement.CloseWindow(this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void InserirTexto(string value)
		{
			this.DeskAutomationService.BaseElement.EnterKeys(value, 0);
		}
		
		public void LiberarTecla(KeyboardEnum key)
		{
			this.DeskAutomationService.BaseElement.LeaveKey(key, this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void MaximizarJanela()
		{
			this.DeskAutomationService.BaseElement.HoldKey(SOW.Automation.Common.KeyboardEnum.LWIN, this.DeskAutomationService.DriverContextInfo.Timeout);
			this.DeskAutomationService.BaseElement.PressKey(SOW.Automation.Common.KeyboardEnum.UP, this.DeskAutomationService.DriverContextInfo.Timeout);
			this.DeskAutomationService.BaseElement.LeaveKey(SOW.Automation.Common.KeyboardEnum.LWIN, this.DeskAutomationService.DriverContextInfo.Timeout);
			this.DeskAutomationService.BaseElement.WaitWhileBusy(0);
		}
		
		public void OndeEstaMouse()
		{
			this.DeskAutomationService.BaseElement.ShowMousePosition(this.DeskAutomationService.DriverContextInfo.Timeout);
			this.DeskAutomationService.BaseElement.Wait(500, this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void PointAndClick(double x, double y)
		{
			this.DeskAutomationService.BaseElement.SetMousePosition(x, y, this.DeskAutomationService.DriverContextInfo.Timeout);
			this.OndeEstaMouse();
			this.DeskAutomationService.BaseElement.MouseClick(this.DeskAutomationService.DriverContextInfo.Timeout);
			this.DeskAutomationService.BaseElement.WaitWhileBusy(this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void PressionarTecla(KeyboardEnum key)
		{
			this.DeskAutomationService.BaseElement.PressKey(key, this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void SegurarTecla(KeyboardEnum key)
		{
			this.DeskAutomationService.BaseElement.HoldKey(key, this.DeskAutomationService.DriverContextInfo.Timeout);
		}
		
		public void SelecionarJanela()
		{
			this.DeskAutomationService.BaseElement.WindowClick(this.DeskAutomationService.DriverContextInfo.Timeout);
			this.DeskAutomationService.BaseElement.WaitWhileBusy(this.DeskAutomationService.DriverContextInfo.Timeout);
		}
	}
}
