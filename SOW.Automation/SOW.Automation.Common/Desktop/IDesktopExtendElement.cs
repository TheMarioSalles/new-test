using System.Collections.Generic;

namespace SOW.Automation.Common.Desktop
{
    public interface IDesktopExtendElement<T>
    {
        void CloseProcess(int timeout);
        void CloseWindow(int timeout);
        void CloseWindow(string url, int timeout);
        void EnterKeys(string keys, int timeout);
        void FieldFocus(T element, int timeout);
        void InitializeDriver(int timeout);
        void InitializeDriver(string fullPath, int timeout);
        void InsertTextByClassName(string fieldClassName, string insertText, int timeout);
        void InsertTextByID(string fieldId, string insertText, int timeout);
        void InsertTextByName(string fieldName, string insertText, int timeout);
        void InsertTextByText(string fieldText, string insertText, int timeout);
        void LeaveKey(KeyboardEnum key, int timeout);
        void OpenApplication(string url, int timeout);
        void OpenWindow(string url, int timeout);
        void PressKey(KeyboardEnum key, int timeout);
        void SearchAndClickByClassName(string fieldClassName, int timeout);
        void SearchAndClickByID(string fieldId, int timeout);
        void SearchAndClickByName(string fieldName, int timeout);
        void SearchAndClickByText(string fieldText, int timeout);
    IList<T> SearchAndReturnByClassName(string fieldClassName, int timeout);
           T SearchAndReturnByID(string ID, int timeout);
           T SearchAndReturnByName(string fieldName, int timeout);
           T SearchAndReturnByText(string fieldText, int timeout);
           T SearchAndReturnFirstByClassName(string fieldClassName, int timeout);
        void TakeDefaultWindow(int timeout);
        void TakeScreenshot(string path, string name, bool printTimeSpan, int timeout);
        void WaitWhileBusy(int timeout);
    }
}
