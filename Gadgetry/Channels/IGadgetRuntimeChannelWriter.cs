namespace Gadgetry.Channels
{
	public interface IGadgetRuntimeChannelWriter
	{
		public IGadgetChannelWriter Template { get; }
		public IGadgetRuntimeChannel Destination { get; }
		public bool HasCompletedWriting { get; }

		void CompleteWriting();
	}
}
