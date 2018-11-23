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
    }
}
