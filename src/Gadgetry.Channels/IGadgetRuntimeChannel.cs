using System.Collections.Generic;

namespace Gadgetry.Channels;

/// <summary>
/// Represents a runtime channel in a producer-consumer data model.
/// </summary>
public interface IGadgetRuntimeChannel
{
	/// <summary>
	/// The template used to create this <see cref="IGadgetChannel"/>.
	/// </summary>
	public IGadgetChannel Template { get; }

	/// <summary>
	/// A collection of all <see cref="IGadgetRuntimeChannelReader"/> that are reading from this <see cref="IGadgetRuntimeChannel"/>.
	/// </summary>
	public IEnumerable<IGadgetRuntimeChannelReader> Readers { get; }

	/// <summary>
	/// A collection of all <see cref="IGadgetRuntimeChannelWriter"/> that are writing to this <see cref="IGadgetRuntimeChannel"/>.
	/// </summary>
	public IEnumerable<IGadgetRuntimeChannelWriter> Writers { get; }
}
