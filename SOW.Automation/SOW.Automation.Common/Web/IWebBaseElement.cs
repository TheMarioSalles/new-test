/*
 * Created by SharpDevelop.
 * User: managsow
 * Date: 22/11/2018
 * Time: 12:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace SOW.Automation.Common.Web
{
	/// <summary>
	/// Description of IWebBaseElement.
	/// </summary>
	public interface IWebBaseElement<T>
	{
	    void CloseProcess(int timeout);
        void InicializeDriver(int timeout);
        void InsertTextByID(string fieldId, string insertText, int timeout);
        void InsertTextByName(string fieldName, string insertText, int timeout);
        void InsertTextByClassName(string fieldClassName, string insertText, int timeout);
        void OpenURL(string url, int timeout);
        void SearchAndClickByID(string ID, int timeout);
           T SearchAndReturnByID(string ID, int timeout);
        void SearchAndClickByCss(string cssSelector, int timeout);
        void DismissAlert();
        void AcceptAlert();
        void TakeDefaultWindow(int seconds);
        void TakeScreenshot(string path, string name, bool printTimeSpan, int timeout);
	}
}
