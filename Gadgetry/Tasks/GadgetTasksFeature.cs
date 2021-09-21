using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Tasks
{
	public class GadgetTasksFeature : IGadgetRunFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly List<GadgetTask> tasks = new();

		public IReadOnlyList<GadgetTask> Tasks => tasks;

		public GadgetTasksFeature()
		{
		}

		async Task IGadgetRunFeature.RunAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken)
		{
			var awaitAll = new List<ValueTask>();

			foreach (var task in Tasks)
			{
				var valueTask = task.TaskCallback(gadgetRuntime, cancellationToken);
				awaitAll.Add(valueTask);
			}

			foreach (var awaitTarget in awaitAll)
			{
				await awaitTarget;
			}
		}
	}
}
