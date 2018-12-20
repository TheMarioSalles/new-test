using System;
namespace SOW.Automation.Common.OCR
{
	public interface IOCRBaseElement<T>
	{
		bool CheckPattern(object pattern, int timeout);
		
		void ClickPattern(object pattern, int timeout);
		
		bool Exists(int timeout);
		
		void InitializeDriver(int timeout);
	}
}
