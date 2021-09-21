using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gadgetry.Channels
{
	public class GadgetRuntimeChannelsFeature : IGadgetRuntimeFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetRuntimeChannelWriter> writers = new();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetRuntimeChannelReader> readers = new();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly Mutex mutex = new();

		public IReadOnlyList<IGadgetRuntimeChannelWriter> Writers => writers;
		public IReadOnlyList<IGadgetRuntimeChannelReader> Readers => readers;
	}
}
