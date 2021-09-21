﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;

namespace Gadgetry.Channels
{
	public class GadgetRuntimeChannel<TModel> : IGadgetRuntimeChannel
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<GadgetRuntimeChannelWriter<TModel>> writers = new();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<GadgetRuntimeChannelReader<TModel>> readers = new();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly Mutex mutex = new();

		public GadgetChannel<TModel> Template { get; }
		public Channel<TModel> InnerChannel { get; }

		public IEnumerable<GadgetRuntimeChannelWriter<TModel>> Writers => writers;
		public IEnumerable<GadgetRuntimeChannelReader<TModel>> Readers => readers;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannel IGadgetRuntimeChannel.Template => Template;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IEnumerable<IGadgetRuntimeChannelWriter> IGadgetRuntimeChannel.Writers => writers;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IEnumerable<IGadgetRuntimeChannelReader> IGadgetRuntimeChannel.Readers => readers;

		public GadgetRuntimeChannel(
			GadgetChannel<TModel> template)
		{
			Template = template;
			InnerChannel = Channel.CreateBounded<TModel>(1024);
		}

		public override string ToString()
		{
			return $"'{Template.Identifier}' {readers.Count}r {writers.Count}w";
		}
	}
}