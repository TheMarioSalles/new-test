using SOW.Automation.Common;
namespace SOW.Automation.Common.Web
{
    public interface IWebAutomationElement<T> : IAutomationElementBase<T>
    {
        void OpenURL(string url, int seconds);
    }
}
