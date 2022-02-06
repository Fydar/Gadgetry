using System.Diagnostics;
using System.Linq;

namespace Gadgetry.Channels
{
	public class GadgetRuntimeChannelWriter<TModel> : IGadgetRuntimeChannelWriter
	{
		public GadgetChannelWriter<TModel> Template { get; }
		public GadgetRuntimeChannel<TModel> Destination { get; }
		public bool HasCompletedWriting { get; private set; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannelWriter IGadgetRuntimeChannelWriter.Template => Template;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetRuntimeChannel IGadgetRuntimeChannelWriter.Destination => Destination;

		public GadgetRuntimeChannelWriter(
			GadgetChannelWriter<TModel> template,
			GadgetRuntimeChannel<TModel> destination)
		{
			Template = template;
			Destination = destination;
		}

		public void CompleteWriting()
		{
			Destination.state.mutex.WaitOne();
			try
			{
				HasCompletedWriting = true;

				if (Destination.Writers.All(writer => writer.HasCompletedWriting))
				{
					Destination.InnerChannel.Writer.TryComplete();
				}
			}
			finally
			{
				Destination.state.mutex.ReleaseMutex();
			}
		}

		public override string ToString()
		{
			return $"'write to '{Destination.Template.Identifier}'";
		}
	}
}
