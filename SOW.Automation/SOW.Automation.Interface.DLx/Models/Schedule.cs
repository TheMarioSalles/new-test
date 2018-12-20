using System;
using System.Collections.Generic;
namespace SOW.Automation.Interface.Dlx.Models
{
	public class Schedule
	{
		public ICollection<Shipment> Shipments { get; set; }
	}
}
