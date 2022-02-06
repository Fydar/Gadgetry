using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Workers;

public sealed class GadgetRuntimeWorkersFeature : IGadgetRuntimeFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetRuntimeWorkerGroup> workerGroups = new();

	public IReadOnlyList<GadgetRuntimeWorkerGroup> WorkerGroups => workerGroups;
}
