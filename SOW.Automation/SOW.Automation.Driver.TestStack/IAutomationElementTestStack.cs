using SOW.Automation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;

namespace SOW.Automation.Driver.TestStack
{
    public interface IAutomationElementTestStack<T> : IAutomationElement<T> where T : IUIItem
    {
        void InicializeDriver(string fullPath);
        void OpenApplication(string url, int seconds);
        void OpenWindow(string url, int seconds);
        void CloseWindow(int seconds);
        void CloseWindow(string url, int seconds);
    }
}
