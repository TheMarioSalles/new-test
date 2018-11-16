using SOW.Automation.Common.WEB;
using SOW.Automation.Services.Gmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Gmail.Pages
{
    public class PageBase
    {
        private AutomationServices _automationServices;

        public AutomationServices AutomationServices
        {
            get { return _automationServices; }
            set { _automationServices = value; }
        }

        public PageBase(DriverContextInfo driverContextInfo)
        {
            this.AutomationServices = new AutomationServices(driverContextInfo);
        }

        public void OpenURL(string url, DriverContextInfo driverContextInfo)
        {
            this.AutomationServices.BaseWebElement.OpenURL(url, driverContextInfo.Timeout);
        }

        public void Close()
        {
            this.AutomationServices.BaseWebElement.CloseProcess();
        }
    }
}
