namespace Gadgetry.Steps;

/// <summary>
/// A model representing a step associated with a <see cref="Gadget"/>.
/// </summary>
public class GadgetStep
{
	/// <summary>
	/// The <see cref="Gadget"/> to be executed during the execution of this step.
	/// </summary>
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
