using System.Linq;

namespace SOW.Automation.Workflow.DHL
{
    public static class Alocacao
    {
        public static void Automatizar(Services Services)
        {
            var loginpage = new Interface.Dlx.Pages.LoginPageHml(Services.WebService, Services.DesktopService);
            var mainpage = new Interface.Dlx.Pages.MainPageHml(Services.WebService, Services.DesktopService);
            var selectApplication = new Interface.Dlx.Windows.SelectApplication(Services.WebService, Services.DesktopService, Services.OCRService);
            var loginRedPrairie = new Interface.Dlx.Windows.LoginRedPrairie(Services.WebService, Services.DesktopService, Services.OCRService);
            var main = new Interface.Dlx.Windows.Main(Services.WebService, Services.DesktopService, Services.OCRService);
            var taskManagement = new Interface.Dlx.Windows.TaskManagement(Services.WebService, Services.DesktopService, Services.OCRService);
            var taskManagementDetailed = new Interface.Dlx.Windows.TaskManagementDetailed(Services.WebService, Services.DesktopService, Services.OCRService);
            var shipmentAllocationOperations = new Interface.Dlx.Windows.ShipmentAllocationOperations(Services.WebService, Services.DesktopService, Services.OCRService);
            var orderInformation = new Interface.Dlx.Windows.OrderInformation(Services.WebService, Services.DesktopService, Services.OCRService);
            var processOrderBatch = new Interface.Dlx.Windows.ProcessOrderBatch(Services.WebService, Services.DesktopService, Services.OCRService);

            return;

            loginpage.OpenURL("https://citrixtest.br.phx-dc.dhl.com/Citrix/storefWeb/", 10);
            loginpage.EfetuarLogin("andre.l.dasilva@dhl.com", "Dhl@112018", 10);
            mainpage.AcessarMondelezAraucari();
            selectApplication.InitializeWindow();
            loginRedPrairie.InitializeWindow();
            main.InitializeWindow();
            taskManagement.InitializeWindow();
            taskManagementDetailed.InitializeWindow();
            System.Collections.Generic.IList<Interface.Dlx.Models.ShipmentDetailed> ShipmentDetaileds = taskManagementDetailed.ModelarItensSelecionados();

            var workSheet = new Interface.Dlx.Excel.ExcelHandler();
            string path = System.String.Concat(System.Environment.CurrentDirectory, @"\Files\");
            string file = @"Planilha de Testes.xlsm";
            bool click = true;

            //lvar ready = ShipmentDetaileds.Where(x => x != null && x.StatusMS != null && x.StatusMS.ToLower().Contains("ready")).ToList();

            foreach (var shipment in ShipmentDetaileds)
            {
                if (shipment.StatusMS.ToLower().Contains("ready"))
                {
                    string boxes = ((shipment.TotalCaixas != null && !System.String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? shipment.TotalCaixas : "0");
                    string pallets = ((shipment.TotalPallets != null && !System.String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? shipment.TotalPallets : "0");
                    string special = ((!System.String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? "1.3" : "1");
                    var rpa = new Interface.Dlx.Excel.Models.RpaDadosStageInfo
                    {
                        Ms = shipment.MS,
                        Sid = shipment.ShipmentID,
                        Status = Interface.Dlx.Excel.Enums.EStatusStage.Ready,
                        FamiliaDlx = Interface.Dlx.Helpers.TemperatureHelper.GetTemperature(shipment.Temperatura),
                        QtdPalets = int.Parse(boxes) / Interface.Dlx.Helpers.FamilyHelper.BoxesToPallets(shipment.Familia) + int.Parse(pallets)
                        //QtdPalets = Convert.ToInt32(int.Parse(((shipment.TotalCaixas != null && !String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? shipment.TotalCaixas : "0")) / Family.ConvertBoxesToPallets(shipment.Familia) + int.Parse(((shipment.TotalPallets != null && !String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? shipment.TotalPallets : "0")) * int.Parse(((!String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? "1.3" : "1")))
                    };
                    var response = workSheet.AlocarObjeto(path, file, rpa);
                    if (response.Alocado)
                    {
                        shipment.StatusMS = "In-Process";
                        shipment.Temperatura = Interface.Dlx.Helpers.TemperatureHelper.GetTemperature(response.RpaDadosStageInfo.FamiliaDlx);
                        
                    	if (!shipmentAllocationOperations.ChecarJanela(@"\OCR\ShipmentAllocationOperationsTitle.png"))
							shipmentAllocationOperations.FecharJanela();
						else {
							if (click) shipmentAllocationOperations.ClicarCampoCarrierMoveID();
							shipmentAllocationOperations.PreencherCampoCarrierMoveID(shipment.MS);
							shipmentAllocationOperations.ClicarBotaoFind();
                        	click = false;
						}
                        
                        if (!orderInformation.ChecarJanela(@"\OCR\OrderInformationTitle.png"))
							orderInformation.FecharJanela();
						else {
							orderInformation.SelecionarTodosItensTabelaListagemAgendamentos();
							orderInformation.ClicarBotaoAllocate();
						}
                        
                        if (!processOrderBatch.ChecarJanela(@"\OCR\ProcessOrderBatchTitle.png"))
							processOrderBatch.FecharJanela();
						else {
							processOrderBatch.ClicarCampoDestinationArea();
							processOrderBatch.PreencherCampoDestinationArea(System.String.Concat("1STGO", shipment.Temperatura));
							processOrderBatch.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
							processOrderBatch.ClicarCampoDestinationArea();
							processOrderBatch.PreencherCampoDestinationArea(System.String.Concat("1STGO", shipment.Temperatura));
							processOrderBatch.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
							processOrderBatch.ClicarCampoDestinationArea();
							processOrderBatch.PreencherCampoDestinationArea(System.String.Concat("1STGO", shipment.Temperatura));
							processOrderBatch.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
							processOrderBatch.ClicarCampoDestinationLocation();
							processOrderBatch.PreencherCampoDestinationLocation(response.Stage);
							processOrderBatch.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
							processOrderBatch.ClicarCampoDestinationLocation();
							processOrderBatch.PreencherCampoDestinationLocation(response.Stage);
							processOrderBatch.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
							processOrderBatch.ClicarCampoDestinationLocation();
							processOrderBatch.PreencherCampoDestinationLocation(response.Stage);
							processOrderBatch.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
							processOrderBatch.ClicarBotaoAllocate();
							if (!processOrderBatch.ChecarJanela(@"\OCR\ProcessOrderBatchAllocationSummary.png"))
								processOrderBatch.FecharJanela();
							else {
								processOrderBatch.ClicarJanelaAllocationSummaryBotaoOk();
							}
						}
                        
                        if (orderInformation.ChecarJanela(@"\OCR\OrderInformationTitle.png"))
                            orderInformation.ClicarBotaoHome();
                    }
                }
            }

            Interface.Dlx.Excel.Services.ExcelService.InsertData(path, file, ShipmentDetaileds);

            main.AbrirJanela();
            main.FecharAplicacao();
        }
    }
}
