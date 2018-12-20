namespace SOW.Automation.Robot.DHL
{
	public static class Workflow
	{
		public static void Alocacao()
		{
            SOW.Automation.Workflow.DHL.Services Services = new SOW.Automation.Workflow.DHL.Services();
            SOW.Automation.Workflow.DHL.Alocacao.Automatizar(Services);
        }
	}
}
