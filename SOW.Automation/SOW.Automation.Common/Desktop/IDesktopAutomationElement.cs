using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Common.Desktop
{
    public interface IDesktopAutomationElement<T>
    {
        void InicializeDriver(string fullPath);
        void CloseWindow(int seconds);
        void CloseWindow(string url, int seconds);
        void OpenApplication(string url, int seconds);
        void OpenWindow(string url, int seconds);
    }
}
