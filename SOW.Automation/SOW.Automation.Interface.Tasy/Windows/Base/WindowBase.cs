using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Service.Desktop;
using System;
namespace SOW.Automation.Interface.Tasy.Windows.Base
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
            try
            {
                this.AutomationService.BaseElement.CloseProcess(timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EnterKeys(string keys, int timeout)
        {
            try
            {
                this.AutomationService.BaseElement.EnterKeys(keys, timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void HoldKey(KeyboardEnum key, int timeout)
        {
            try
            {
                this.AutomationService.BaseElement.HoldKey(key, timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LeaveKey(KeyboardEnum key, int timeout)
        {
            try
            {
                this.AutomationService.BaseElement.LeaveKey(key, timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertDataInFieldByID(string key, string value, int timeout)
        {
            this.AutomationService.BaseElement.InsertTextByID(key, value, this.AutomationService.DriverContextInfo.Timeout);
        }

        public void Open(string url, int timeout)
        {
            try
            {
                this.AutomationService.BaseElement.OpenWindow(url, timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PressKey(KeyboardEnum key, int timeout)
        {
            try
            {
                this.AutomationService.BaseElement.PressKey(key, timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Shortcut(KeyboardEnum key, string keys, int timeout)
        {
            try
            {
                this.AutomationService.BaseElement.HoldKey(key, timeout);
                this.AutomationService.BaseElement.EnterKeys(keys, timeout);
                this.AutomationService.BaseElement.LeaveKey(key, timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
