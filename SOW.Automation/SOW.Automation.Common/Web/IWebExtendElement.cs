namespace SOW.Automation.Common.Web
{
    public interface IWebExtendElement<T>
    {
        void CloseProcess(int seconds);
        void InicializeDriver(int seconds);
        void InsertTextByID(string fieldId, string insertText, int seconds);
        void InsertTextByName(string fieldName, string insertText, int seconds);
        void InsertTextByClassName(string fieldClassName, string insertText, int seconds);
        void OpenURL(string url, int seconds);
        void SearchAndClickByID(string ID, int seconds);
           T SearchAndReturnByID(string ID, int seconds);
        void TakeDefaultWindow(int seconds);
        void TakeScreenshot(string path, string name, bool printTimeSpan, int seconds);
    }
}
