namespace Gadgetry.Workers;

public static class IGadgetBuilderExtensions
{
	public static IGadgetBuilder UseWorker(
		this IGadgetBuilder gadgetBuilder,
		Gadget workerGadget)
	{
		gadgetBuilder.Configure(configure =>
		{
			var feature = configure.Features.GetOrCreateFeature<GadgetWorkersFeature>();

			feature.workerGroups.Add(new GadgetWorkerGroup(workerGadget));
		});

		return gadgetBuilder;
	}

	public static IGadgetBuilder UseWorker(
		this IGadgetBuilder gadgetBuilder,
		Gadget workerGadget,
		GadgetWorkerOptions workerGadgetOptions)
	{
		gadgetBuilder.Configure(configure =>
		{
			var feature = configure.Features.GetOrCreateFeature<GadgetWorkersFeature>();

			feature.workerGroups.Add(new GadgetWorkerGroup(workerGadget, workerGadgetOptions));
		});

		return gadgetBuilder;
	}

	public static IGadgetBuilder UseWorker(
		this IGadgetBuilder gadgetBuilder,
		IGadgetBuilder workerGadget)
	{
		gadgetBuilder.Configure(configure =>
		{
			var feature = configure.Features.GetOrCreateFeature<GadgetWorkersFeature>();

			string stepIdentifier = $"{configure.Identifier}-worker{feature.workerGroups.Count}";

			feature.workerGroups.Add(new GadgetWorkerGroup(workerGadget.Build(stepIdentifier)));
		});

		return gadgetBuilder;
	}

	public static IGadgetBuilder UseWorker(
		this IGadgetBuilder gadgetBuilder,
		IGadgetBuilder workerGadget,
		GadgetWorkerOptions workerGadgetOptions)
	{
		gadgetBuilder.Configure(configure =>
		{
			var feature = configure.Features.GetOrCreateFeature<GadgetWorkersFeature>();

			string stepIdentifier = $"{configure.Identifier}-worker{feature.workerGroups.Count}";

			feature.workerGroups.Add(new GadgetWorkerGroup(workerGadget.Build(stepIdentifier), workerGadgetOptions));
		});

		return gadgetBuilder;
	}
}
