namespace Gadgetry.Steps
{
	public static class IGadgetBuilderExtensions
	{
		public static IGadgetBuilder UseStep(
			this IGadgetBuilder gadgetBuilder,
			Gadget stepGadget)
		{
			gadgetBuilder.Configure(configure =>
			{
				var feature = configure.Features.GetOrCreateFeature<GadgetStepsFeature>();
				feature.steps.Add(new GadgetStep(stepGadget));
			});
			return gadgetBuilder;
		}

		public static IGadgetBuilder UseStep(
			this IGadgetBuilder gadgetBuilder,
			IGadgetBuilder stepGadget)
		{
			gadgetBuilder.Configure(configure =>
			{
				var feature = configure.Features.GetOrCreateFeature<GadgetStepsFeature>();
				string? stepIdentifier = $"{configure.Identifier}-step{feature.steps.Count}";
				feature.steps.Add(new GadgetStep(stepGadget.Build(stepIdentifier)));
			});
			return gadgetBuilder;
		}
	}
}
