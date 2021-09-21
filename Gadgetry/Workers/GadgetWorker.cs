namespace Gadgetry.Workers
{
	public class GadgetWorker
	{
		public Gadget WorkerGadget { get; }
		public GadgetWorkerOptions Options { get; }

		internal GadgetWorker(Gadget workerGadget)
		{
			WorkerGadget = workerGadget;
			Options = new GadgetWorkerOptions();
		}

		internal GadgetWorker(Gadget workerGadget, GadgetWorkerOptions options)
		{
			WorkerGadget = workerGadget;
			Options = options;
		}

		public override string ToString()
		{
			return $"{Options.Workers}x {WorkerGadget}";
		}
	}
}
