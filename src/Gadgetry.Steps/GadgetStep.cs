namespace Gadgetry.Steps;

public class GadgetStep
{
	public Gadget StepGadget { get; }

	internal GadgetStep(Gadget stepGadget)
	{
		StepGadget = stepGadget;
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"{StepGadget}";
	}
}
