using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Workers;

/// <summary>
/// A feature used to interact with the <b>workers</b> associated with an <see cref="GadgetRuntime"/>.
/// </summary>
public sealed class GadgetRuntimeWorkersFeature : IGadgetRuntimeFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetRuntimeWorkerGroup> workerGroups = new();

	/// <summary>
	/// A collection of all worker groups associated with the <see cref="GadgetRuntime"/>.
	/// </summary>
	public IReadOnlyList<GadgetRuntimeWorkerGroup> WorkerGroups => workerGroups;
}
