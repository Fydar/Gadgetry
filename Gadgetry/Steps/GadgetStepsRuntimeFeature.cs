using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Steps
{
	public sealed class GadgetStepsRuntimeFeature : IGadgetRuntimeFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly List<GadgetRuntime> steps = new();

		public IReadOnlyList<GadgetRuntime> Steps => steps;
	}
}
