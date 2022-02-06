using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Channels;

public class GadgetRuntimeChannelsFeature : IGadgetRuntimeFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetRuntimeChannelWriter> writers = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetRuntimeChannelReader> readers = new();

	public IReadOnlyList<IGadgetRuntimeChannelWriter> Writers => writers;
	public IReadOnlyList<IGadgetRuntimeChannelReader> Readers => readers;
}
