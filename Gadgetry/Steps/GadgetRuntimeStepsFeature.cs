using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Steps;

public sealed class GadgetRuntimeStepsFeature : IGadgetRuntimeFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetRuntime> steps = new();

	public IReadOnlyList<GadgetRuntime> Steps => steps;
}
