namespace Gadgetry.Visualisation;

public static class GadgetRuntimeExtensions
{
	public static void SetTerm(
		this GadgetRuntime gadgetRuntime,
		VisualiserTermWriter termWriter,
		double value)
	{
		var stateChannelsFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateVisualisationFeature>();

		stateChannelsFeature.SetTerm(termWriter, value);
	}

	public static void IncrementTerm(
		this GadgetRuntime gadgetRuntime,
		VisualiserTermWriter termWriter,
		double increment)
	{
		var stateChannelsFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateVisualisationFeature>();

		stateChannelsFeature.IncrementTerm(termWriter, increment);
	}
}
