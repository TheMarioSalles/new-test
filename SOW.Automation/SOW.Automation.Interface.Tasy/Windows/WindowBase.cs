using SOW.Automation.Common;
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
        public DesktopService AutomationService
        {
            get { return _automationService; }
            set { _automationService = value; }
        }

        public WindowBase(DesktopDriverContextInfo driverContextInfo) { this.AutomationService = new DesktopService(driverContextInfo); }

        public WindowBase(DesktopService desktopService) { this.AutomationService = desktopService; }

        public void Close(int timeout)
        {
            this.AutomationService.BaseElement.CloseProcess(timeout);
        }

        public void EnterKeys(string keys, int timeout)
        {
            this.AutomationService.BaseElement.EnterKeys(keys, timeout);
        }

        public void LeaveKey(KeyboardEnum key, int timeout)
        {
            this.AutomationService.BaseElement.LeaveKey(key, timeout);
        }

        public void Open(string url, int timeout)
        {
            this.AutomationService.BaseElement.OpenWindow(url, timeout);
        }

        public void PressKey(KeyboardEnum key, int timeout)
        {
            this.AutomationService.BaseElement.PressKey(key, timeout);
        }

        public void Shortcut(KeyboardEnum key, string keys, int timeout)
        {
            this.AutomationService.BaseElement.PressKey(key, timeout);
            this.AutomationService.BaseElement.EnterKeys(keys, timeout);
            this.AutomationService.BaseElement.LeaveKey(key, timeout);
        }
    }
}
