namespace Gadgetry.Workers
{
	public class GadgetWorkerOptions
	{
		public int Workers { get; } = 1;

		public GadgetWorkerOptions()
		{

		}

		public GadgetWorkerOptions(int workers)
		{
			Workers = workers;
		}
	}
}
