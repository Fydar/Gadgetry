using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Steps;

/// <summary>
/// A feature used to interact with the <b>steps</b> associated with an <see cref="GadgetRuntime"/>.
/// </summary>
public sealed class GadgetRuntimeStepsFeature : IGadgetRuntimeFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetRuntime> steps = new();

	/// <summary>
	/// All <b>steps</b> associated with the <see cref="GadgetRuntime"/>.
	/// </summary>
	public IReadOnlyList<GadgetRuntime> Steps => steps;
}
