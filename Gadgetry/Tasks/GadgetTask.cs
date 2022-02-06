namespace Gadgetry.Tasks;

public class GadgetTask
{
	public GadgetTaskCallbackAsync TaskCallback { get; }

	internal GadgetTask(GadgetTaskCallbackAsync taskCallback)
	{
		TaskCallback = taskCallback;
	}
}
