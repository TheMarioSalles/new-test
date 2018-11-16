using SOW.Automation.Common.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Gmail.Pages
{
    public class LoginPage : PageBase
    {
        private DriverContextInfo _driverContextInfo;

        public DriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        public LoginPage(DriverContextInfo driverContextInfo) : base(driverContextInfo)
        {
            this.DriverContextInfo = driverContextInfo;
        }

        public void SearchAndInsertDataByID(string ID, string value)
        {
            this.AutomationServices.BaseWebElement.InsertTextInLabelByName(ID, value, DriverContextInfo.Timeout);
        }

        public void SearchAndInsertDataByName(string name, string value)
        {
            this.AutomationServices.BaseWebElement.InsertTextInLabelByName(name, value, DriverContextInfo.Timeout);
        }

        public void LoginButtonClick(string ID)
        {
            this.AutomationServices.BaseWebElement.SearchAndClickByID(ID, DriverContextInfo.Timeout);
        }
    }
}
