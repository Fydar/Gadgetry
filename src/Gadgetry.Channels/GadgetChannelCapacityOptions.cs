using System.Threading.Channels;

namespace Gadgetry.Channels;

/// <summary>
/// Options used to configure the capacity of an <see cref="IGadgetChannel"/>.
/// </summary>
public class GadgetChannelCapacityOptions
{
	/// <summary>
	/// The capacity of the channel.
	/// </summary>
	public int Capacity { get; set; } = 512;

	/// <summary>
	/// Specifies the behavior to use when writing to a bounded channel that is already full.
	/// </summary>
	public BoundedChannelFullMode FullMode { get; set; } = BoundedChannelFullMode.Wait;
}
