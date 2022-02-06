namespace Gadgetry.Workers;

/// <summary>
/// Options associated with a group of workers that use a common <see cref="Gadget"/>.
/// </summary>
public class GadgetWorkerGroup
{
	/// <summary>
	/// The <see cref="Gadget"/> executed for each worker.
	/// </summary>
	public Gadget WorkerGadget { get; }

	/// <summary>
	/// Options used to control the behaviour of the workers.
	/// </summary>
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

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"{Options.Workers}x {WorkerGadget}";
	}
}
