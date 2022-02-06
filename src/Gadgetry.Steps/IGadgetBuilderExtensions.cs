namespace Gadgetry.Steps;

/// <summary>
/// Extension methods of <see cref="IGadgetBuilder"/> for adding <b>"step"</b> support.
/// </summary>
public static class IGadgetBuilderExtensions
{
	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> with a step executed during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="stepGadget">The step executed during the <see cref="GadgetRuntime"/> execution.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
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

	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> with a step executed during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="stepGadget">The step executed during the <see cref="GadgetRuntime"/> execution.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
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
