namespace Gadgetry.Workers;

public class GadgetWorkerGroup
{
	public Gadget WorkerGadget { get; }
	public GadgetWorkerOptions Options { get; }

	internal GadgetWorkerGroup(Gadget workerGadget)
	{
		WorkerGadget = workerGadget;
		Options = new GadgetWorkerOptions();
	}

	internal GadgetWorkerGroup(Gadget workerGadget, GadgetWorkerOptions options)
	{
		WorkerGadget = workerGadget;
		Options = options;
	}

	public override string ToString()
	{
		return $"{Options.WorkerGroups}x {WorkerGadget}";
	}
}
