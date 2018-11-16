namespace SOW.Automation.Common
{
    public interface IAutomationElement<T>
    {
        void InicializeDriver();
        void InsertTextInLabelByID(string labelId, string inputText, int seconds);
        void InsertTextInLabelByName(string labelName, string inputText, int seconds);
        void OpenURL(string url, int seconds);
        void SearchAndClickByID(string ID, int seconds);
           T SearchAndReturnByID(string ID, int seconds);
        void TakeDefaultWindow();
        void TakeScreenshot(string path, string name, bool printTimeSpan);
        void CloseProcess();
    }
}
