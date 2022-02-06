using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Tasks;

/// <summary>
/// A feature used to interact with the <b>"tasks"</b> functionality of a <see cref="Gadget"/>.
/// </summary>
public class GadgetTasksFeature : IGadgetRunFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetTask> tasks = new();

	/// <summary>
	/// A collection of all <see cref="GadgetTask"/> that are associated with the <see cref="Gadget"/>.
	/// </summary>
	/// <remarks>
	/// These tasks are executed during the <see cref="GadgetRuntime"/> execution.
	/// </remarks>
	public IReadOnlyList<GadgetTask> Tasks => tasks;

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetTasksFeature"/> class.
	/// </summary>
	public GadgetTasksFeature()
	{
	}

	async Task IGadgetRunFeature.RunAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken)
	{
		var awaitAll = new List<Task>();

		foreach (var task in Tasks)
		{
			var taskRunner = Task.Run(() => task.TaskCallback(gadgetRuntime, cancellationToken), cancellationToken);
			awaitAll.Add(taskRunner);
		}

		foreach (var awaitTarget in awaitAll)
		{
			await awaitTarget;
		}
	}
}
