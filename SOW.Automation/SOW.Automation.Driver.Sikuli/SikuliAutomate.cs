using System;
using System.Collections.Generic;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using SOW.Automation.Common.OCR;

namespace SOW.Automation.Driver.Sikuli
{
	public class SikuliAutomate<T> : IOCRBaseElement<T>
	{
		private APILauncher _application;
		public APILauncher Application { get { return _application; } set { _application = value; } }
		
		private Screen _screen;
		public Screen Screen { get { return _screen; } set { _screen = value; } }

		private OCRDriverContextInfo _driverContextInfo;
		public OCRDriverContextInfo DriverContextInfo { get { return _driverContextInfo; } set { _driverContextInfo = value; } }

		public SikuliAutomate(OCRDriverContextInfo config)
		{
			try {
				this.DriverContextInfo = config;
				this.InitializeDriver(this.DriverContextInfo.Timeout);
                	
			} catch (System.Exception) {
				throw;
			}
		}
		
		public bool CheckPattern(object pattern, int timeout)
		{
			try {
            	this.Screen = new Screen();
            	this.Screen.Wait((Pattern)pattern, timeout);
            	return true;
			} catch (Exception) {
				return false;
			}
		}
		
		public void ClickPattern(object pattern, int timeout)
		{
			try {
            	this.Screen = new Screen();
            	this.Screen.Click((Pattern)pattern, true);
			} catch (Exception) {
				throw;
			}
		}
		
		public bool Exists(int timeout)
		{
			try {
				this.Application.VerifyJarExists();
				return true;
			} catch (Exception) {
				return false;
			}
		}
		
		public void InitializeDriver(int timeout)
		{
			try {
            	this.Application = new APILauncher(true);
			} catch (Exception) {
				throw;
			}
		}
	}
}