using System.Threading.Channels;

namespace Gadgetry.Channels
{
	public class GadgetChannelCapacityOptions
	{
		public int Capacity { get; set; } = 512;
		public BoundedChannelFullMode FullMode { get; set; } = BoundedChannelFullMode.Wait;
	}
}
