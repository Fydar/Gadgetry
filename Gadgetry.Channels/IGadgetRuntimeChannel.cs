using System.Collections.Generic;

namespace Gadgetry.Channels;

public interface IGadgetRuntimeChannel
{
	public IGadgetChannel Template { get; }

	public IEnumerable<IGadgetRuntimeChannelReader> Readers { get; }

	public IEnumerable<IGadgetRuntimeChannelWriter> Writers { get; }
}
