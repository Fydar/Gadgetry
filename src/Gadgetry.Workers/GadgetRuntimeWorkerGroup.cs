using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Workers;

/// <summary>
/// A worker group associated with the <see cref="GadgetRuntime"/>.
/// </summary>
public sealed class GadgetRuntimeWorkerGroup
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetRuntime> workers = new();

	/// <summary>
	/// A collection of all worker <see cref="GadgetRuntime"/> associated with the <see cref="GadgetRuntimeWorkerGroup"/>.
	/// </summary>
	public IReadOnlyList<GadgetRuntime> Workers => workers;
}
