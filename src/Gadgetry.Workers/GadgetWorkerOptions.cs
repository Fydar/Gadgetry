namespace Gadgetry.Workers;

/// <summary>
/// Options used to control the behaviour of the workers.
/// </summary>
public class GadgetWorkerOptions
{
	/// <summary>
	/// The quantity of workers to be created from the supplied <see cref="Gadget"/>.
	/// </summary>
	public int Workers { get; } = 1;

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetWorkerOptions"/> class.
	/// </summary>
	public GadgetWorkerOptions()
	{
	}

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetWorkerOptions"/> class with a specified number of workers.
	/// </summary>
	/// <param name="workers">The quantity of workers to be created from the supplied <see cref="Gadget"/>.</param>
	public GadgetWorkerOptions(int workers)
	{
		Workers = workers;
	}
}
