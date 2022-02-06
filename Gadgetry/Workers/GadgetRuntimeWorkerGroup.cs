using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Workers
{
	public sealed class GadgetRuntimeWorkerGroup
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly List<GadgetRuntime> workers = new();

		public IReadOnlyList<GadgetRuntime> Workers => workers;
	}
}
