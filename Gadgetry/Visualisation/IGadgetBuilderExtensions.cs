namespace Gadgetry.Visualisation;

public static class IGadgetBuilderExtensions
{
	public static IGadgetBuilder AddVisualiser<TVisualiser>(
		this IGadgetBuilder gadgetBuilder,
		out GadgetVisualiser<TVisualiser> visualiser,
		TVisualiser design)
		where TVisualiser : IVisualiser
	{
		var gadgetVisualiser = new GadgetVisualiser<TVisualiser>(design);
		visualiser = gadgetVisualiser;

		gadgetBuilder.Configure(configure =>
		{
			var feature = configure.Features.GetOrCreateFeature<GadgetVisualisationFeature>();

			feature.visualisers.Add(gadgetVisualiser);
		});

		return gadgetBuilder;
	}
}
