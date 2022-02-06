using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Channels;

/// <summary>
/// A feature used to interact with the "channels" associated with a <see cref="GadgetRuntime"/>.
/// </summary>
public class GadgetRuntimeChannelsFeature : IGadgetRuntimeFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetRuntimeChannelWriter> writers = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetRuntimeChannelReader> readers = new();

	/// <summary>
	/// A collection of all <see cref="IGadgetRuntimeChannelWriter"/> associated with the <see cref="GadgetRuntime"/>.
	/// </summary>
	public IReadOnlyList<IGadgetRuntimeChannelWriter> Writers => writers;

	/// <summary>
	/// A collection of all <see cref="IGadgetRuntimeChannelReader"/> associated with the <see cref="GadgetRuntime"/>.
	/// </summary>
	public IReadOnlyList<IGadgetRuntimeChannelReader> Readers => readers;
}
