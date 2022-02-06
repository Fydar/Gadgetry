namespace Gadgetry.Visualisation;

public class GadgetRuntimeVisualiser
{
	public IGadgetVisualiser Template { get; }

	public GadgetRuntimeVisualiser(IGadgetVisualiser template)
	{
		Template = template;
	}
}
