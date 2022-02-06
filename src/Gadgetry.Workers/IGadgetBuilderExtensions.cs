namespace Gadgetry.Workers;

/// <summary>
/// Extension methods of <see cref="IGadgetBuilder"/> for adding <b>"worker"</b> support.
/// </summary>
public static class IGadgetBuilderExtensions
{
	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> with a worker executed during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="workerGadget">The worker executed during the <see cref="GadgetRuntime"/> execution.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
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

	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> with a worker executed during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="workerGadget">The worker executed during the <see cref="GadgetRuntime"/> execution.</param>
	/// <param name="workerGadgetOptions">Options used to configure the behaviour of the worker.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
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

	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> with a worker executed during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="workerGadget">The worker executed during the <see cref="GadgetRuntime"/> execution.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
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

	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> with a worker executed during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="workerGadget">The worker executed during the <see cref="GadgetRuntime"/> execution.</param>
	/// <param name="workerGadgetOptions">Options used to configure the behaviour of the worker.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
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
