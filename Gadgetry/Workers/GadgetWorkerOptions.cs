namespace Gadgetry.Workers
{
	public class GadgetWorkerOptions
	{
		public int WorkerGroups { get; } = 1;

		public GadgetWorkerOptions()
		{

		}

		public GadgetWorkerOptions(int workers)
		{
			WorkerGroups = workers;
		}
	}
}
