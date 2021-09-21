using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Workers
{
	public sealed class GadgetWorkersFeature : IGadgetInitFeature, IGadgetRunFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly List<GadgetWorker> workers = new();

		public IReadOnlyList<GadgetWorker> Workers => workers;

		public GadgetWorkersFeature()
		{
		}

		void IGadgetInitFeature.Init(GadgetRuntime gadgetRuntime)
		{
			var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetWorkersRuntimeFeature>();

			foreach (var worker in workers)
			{
				for (int i = 0; i < worker.Options.Workers; i++)
				{
					var workerGadgetRuntime = gadgetRuntime.ExtendWith(worker.WorkerGadget);

					runtimeFeature.workers.Add(workerGadgetRuntime);
				}
			}
		}

		async Task IGadgetRunFeature.RunAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken)
		{
			var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetWorkersRuntimeFeature>();

			var tasks = new List<Task>();
			foreach (var worker in runtimeFeature.workers)
			{
				var workerGadgetRuntimeTask = worker.RunAsync(cancellationToken).AsTask();

				var errorHandled = workerGadgetRuntimeTask.ContinueWith(continued =>
				{
					if (continued.IsFaulted)
					{
						Console.WriteLine(continued.Exception +
							$"Worker \"{worker.Template.Identifier}\" failed unexpectedly.");
					}
				}, cancellationToken);

				tasks.Add(errorHandled);
			}

			await Task.WhenAll(tasks);
		}
	}
}
