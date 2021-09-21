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
			Destination.mutex.WaitOne();

			if (HasCompletedWriting)
			{
				Destination.mutex.ReleaseMutex();
				return;
			}
			HasCompletedWriting = true;

			if (Destination.Writers.All(writer => writer.HasCompletedWriting))
			{
				Destination.InnerChannel.Writer.Complete();
			}

			Destination.mutex.ReleaseMutex();
		}

		public override string ToString()
		{
			return $"'write to '{Destination.Template.Identifier}'";
		}
	}
}
