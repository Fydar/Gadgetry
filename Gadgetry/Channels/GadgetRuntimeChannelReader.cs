using System.Diagnostics;

namespace Gadgetry.Channels
{
	public class GadgetRuntimeChannelReader<TModel> : IGadgetRuntimeChannelReader
	{
		public GadgetChannelReader<TModel> Template { get; }
		public GadgetRuntimeChannel<TModel> Source { get; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannelReader IGadgetRuntimeChannelReader.Template => Template;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetRuntimeChannel IGadgetRuntimeChannelReader.Source => Source;

		public GadgetRuntimeChannelReader(
			GadgetChannelReader<TModel> template,
			GadgetRuntimeChannel<TModel> source)
		{
			Template = template;
			Source = source;
		}

		public override string ToString()
		{
			return $"read from '{Source.Template.Identifier}'";
		}
	}
}
