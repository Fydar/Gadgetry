namespace Gadgetry.Workers
{
	public static class IGadgetBuilderExtensions
	{
		public static IGadgetBuilder UseWorker(
			this IGadgetBuilder gadgetBuilder,
			Gadget workerGadget)
		{
			gadgetBuilder.Configure(configure =>
			{
				var feature = configure.Features.GetOrCreateFeature<GadgetWorkersFeature>();

				feature.workers.Add(new GadgetWorker(workerGadget));
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

				feature.workers.Add(new GadgetWorker(workerGadget, workerGadgetOptions));
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

				string stepIdentifier = $"{configure.Identifier}-worker{feature.workers.Count}";

				feature.workers.Add(new GadgetWorker(workerGadget.Build(stepIdentifier)));
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

				string stepIdentifier = $"{configure.Identifier}-worker{feature.workers.Count}";

				feature.workers.Add(new GadgetWorker(workerGadget.Build(stepIdentifier), workerGadgetOptions));
			});

			return gadgetBuilder;
		}
	}
}
