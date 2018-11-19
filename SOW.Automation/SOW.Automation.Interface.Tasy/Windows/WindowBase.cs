using SOW.Automation.Common.Desktop;
using SOW.Automation.Service.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Tasy.Windows
{
    public class WindowBase
    {
        private DesktopService _automationService;
        protected DesktopService AutomationService
        {
            get { return _automationService; }
            set { _automationService = value; }
        }

        public WindowBase(DesktopDriverContextInfo driverContextInfo)
        {
            this.AutomationService = new DesktopService(driverContextInfo);
        }

        public void Open(string url, DesktopDriverContextInfo driverContextInfo)
        {
            this.AutomationService.BaseElement.OpenWindow("Identificação de Usuário", driverContextInfo.Timeout);
        }

        public void Close(DesktopDriverContextInfo driverContextInfo)
        {
            this.AutomationService.BaseElement.CloseProcess(driverContextInfo.Timeout);
        }
    }
}
