namespace Gadgetry.Tasks;

/// <summary>
/// A task associated with a <see cref="Gadget"/>.
/// </summary>
public class GadgetTask
{
	/// <summary>
	/// The callback associated with this <see cref="GadgetTask"/> that is invoked during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	internal GadgetTaskCallbackAsync TaskCallback { get; }

	internal GadgetTask(GadgetTaskCallbackAsync taskCallback)
	{
		TaskCallback = taskCallback;
	}
}
