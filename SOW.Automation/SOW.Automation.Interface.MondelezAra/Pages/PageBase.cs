﻿using SOW.Automation.Common.Web;
using SOW.Automation.Service.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.MondelezAra.Pages
{
    public class PageBase
    {
        private WebService _automationService;
        protected WebService AutomationService
        {
            get { return _automationService; }
            set { _automationService = value; }
        }

        public PageBase(WebDriverContextInfo driverContextInfo)
        {
            this.AutomationService = new WebService(driverContextInfo);
        }

        public void OpenURL(string url, WebDriverContextInfo driverContextInfo)
        {
            this.AutomationService.BaseWebElement.OpenURL(url, driverContextInfo.Timeout);
        }

        public void Close(WebDriverContextInfo driverContextInfo)
        {
            this.AutomationService.BaseWebElement.CloseProcess(driverContextInfo.Timeout);
        }
    }
}
