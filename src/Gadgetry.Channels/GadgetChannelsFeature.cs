using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Channels;

/// <summary>
/// A feature used to interact with the <b>"channels"</b> associated with an <see cref="Gadget"/>.
/// </summary>
public class GadgetChannelsFeature : IGadgetFinaliseFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetChannel> channels = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetChannelWriter> writers = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<IGadgetChannelReader> readers = new();

	/// <summary>
	/// A collection of all channels that this <see cref="Gadget"/> interacts with.
	/// </summary>
	public IReadOnlyList<IGadgetChannel> Channels => channels;

	/// <summary>
	/// A collection representing all of the writers that are writing to this channel.
	/// </summary>
	public IReadOnlyList<IGadgetChannelWriter> Writers => writers;

	/// <summary>
	/// A collection representing all of the readers that are reading from this channel.
	/// </summary>
	public IReadOnlyList<IGadgetChannelReader> Readers => readers;

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetChannelsFeature"/>.
	/// </summary>
	public GadgetChannelsFeature()
	{
	}

	Task IGadgetFinaliseFeature.FinaliseAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken)
	{
		var channelsFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeChannelsFeature>();

		foreach (var executionWriter in channelsFeature.writers)
		{
			executionWriter.CompleteWriting();
		}
		return Task.CompletedTask;
	}
}
