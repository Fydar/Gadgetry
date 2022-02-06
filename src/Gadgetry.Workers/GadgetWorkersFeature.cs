using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Workers;

public sealed class GadgetWorkersFeature : IGadgetInitFeature, IGadgetRunFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetWorkerGroup> workerGroups = new();

	public IReadOnlyList<GadgetWorkerGroup> WorkerGroups => workerGroups;

	public GadgetWorkersFeature()
	{
	}

	void IGadgetInitFeature.Init(GadgetRuntime gadgetRuntime)
	{
		var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeWorkersFeature>();

		foreach (var workerGroup in workerGroups)
		{
			var workerGadgetRuntimeGroup = new GadgetRuntimeWorkerGroup();

			for (int i = 0; i < workerGroup.Options.WorkerGroups; i++)
			{
				var workerGadgetRuntime = gadgetRuntime.ExtendWith(workerGroup.WorkerGadget);

				workerGadgetRuntimeGroup.workers.Add(workerGadgetRuntime);
			}

			runtimeFeature.workerGroups.Add(workerGadgetRuntimeGroup);
		}
	}

	async Task IGadgetRunFeature.RunAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken)
	{
		var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeWorkersFeature>();

		var tasks = new List<Task>();
		foreach (var workerGroup in runtimeFeature.workerGroups)
		{
			foreach (var worker in workerGroup.workers)
			{
				var workerGadgetRuntimeTask = worker.RunAsync(cancellationToken);

				tasks.Add(workerGadgetRuntimeTask);
			}
		}

		await Task.WhenAll(tasks);
	}
}
