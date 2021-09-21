namespace Gadgetry.Channels
{
	public interface IGadgetRuntimeChannelReader
	{
		public IGadgetChannelReader Template { get; }
		public IGadgetRuntimeChannel Source { get; }
	}
}
