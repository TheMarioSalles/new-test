namespace SOW.Automation.Robot.DHL
{
	class Program
	{
		public static void Main(string[] args)
		{
			//new System.Threading.Timer((e) => Workflow.Alocacao(), null, System.TimeSpan.Zero, System.TimeSpan.FromMinutes(30));
			Workflow.Alocacao();
		}
	}
}