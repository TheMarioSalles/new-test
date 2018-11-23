using SOW.Automation.Interface.Tasy.Windows.Base;
using SOW.Automation.Service.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Tasy.Windows
{
    public class IdentificacaoBeneficiariosMessageBox : WindowBase
    {
        public IdentificacaoBeneficiariosMessageBox(DesktopService desktopService) : base(desktopService)
        {
            this.AutomationService = desktopService;
        }
        
        public void ClicarBotaoOk()
        {
            this.AutomationService.BaseElement.SearchAndClickByText("OK", this.AutomationService.DriverContextInfo.Timeout);
        }
    }
}
