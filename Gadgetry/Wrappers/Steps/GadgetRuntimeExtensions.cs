using Gadgetry.Steps;

namespace Gadgetry.Wrappers.Steps
{
	public static class GadgetRuntimeExtensions
	{
		public static void EnqueueStep<TOutput>(
			this GadgetRuntime gadgetRuntime,
			GadgetFunc<TOutput> stepGadget)
		{
			var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeStepsFeature>();

			var stepRuntime = gadgetRuntime.ExtendWith(stepGadget.InnerGadget);
			runtimeFeature.steps.Add(stepRuntime);
		}

		public static void EnqueueStep<TInput, TOutput>(
			this GadgetRuntime gadgetRuntime,
			GadgetFunc<TInput, TOutput> stepGadget)
		{
			var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeStepsFeature>();

			var stepRuntime = gadgetRuntime.ExtendWith(stepGadget.InnerGadget);
			runtimeFeature.steps.Add(stepRuntime);
		}
	}
}
