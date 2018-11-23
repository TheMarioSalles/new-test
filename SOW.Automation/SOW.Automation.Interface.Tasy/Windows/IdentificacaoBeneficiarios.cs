using System;
using SOW.Automation.Common;
using SOW.Automation.Interface.Tasy.Windows.Base;
using SOW.Automation.Service.Desktop;
using TestStack.White.UIItems;
namespace SOW.Automation.Interface.Tasy.Windows
{
    public class IdentificacaoBeneficiarios : WindowBase
    {
        private IdentificacaoBeneficiariosMessageBox IdentificacaoBeneficiariosMessageBox { get; set; }

        public IdentificacaoBeneficiarios(DesktopService desktopService) : base(desktopService)
        {
            this.AutomationService = desktopService;
            //Initialize();
        }

        private void Initialize()
        {
            InsertDataInFieldByID("264116", "00021971400095000", this.AutomationService.DriverContextInfo.Timeout);
            PressionarTecla(KeyboardEnum.RETURN);
            if (ValidarCampo("1116066"))
            {
                FecharMensagem();
                this.AutomationService.BaseElement.TakeDefaultWindow(this.AutomationService.DriverContextInfo.Timeout);
            }
        }

        private void PressionarTecla(KeyboardEnum key)
        {
            this.AutomationService.BaseElement.PressKey(key, this.AutomationService.DriverContextInfo.Timeout);
            this.AutomationService.BaseElement.LeaveKey(key, this.AutomationService.DriverContextInfo.Timeout);
        }

        private bool ValidarCampo(string key)
        {
            TextBox element = (TextBox)this.AutomationService.BaseElement.SearchAndReturnByID(key, this.AutomationService.DriverContextInfo.Timeout);
            return String.IsNullOrWhiteSpace(element.Text);
        }

        private void FecharMensagem()
        {
            this.IdentificacaoBeneficiariosMessageBox = new IdentificacaoBeneficiariosMessageBox(this.AutomationService);
            this.IdentificacaoBeneficiariosMessageBox.Close(this.AutomationService.DriverContextInfo.Timeout);
        }
    }
}
