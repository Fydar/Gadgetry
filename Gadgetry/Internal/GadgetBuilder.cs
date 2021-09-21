using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Internal
{
	internal class GadgetBuilder : IGadgetBuilder
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<Action<GadgetOptions>> configureCallbacks = new();

		internal GadgetBuilder()
		{
		}

		public IGadgetBuilder Configure(Action<GadgetOptions> options)
		{
			configureCallbacks.Add(options);
			return this;
		}

		public Gadget Build(string identifier)
		{
			var options = new GadgetOptions(identifier);

			foreach (var configureCallback in configureCallbacks)
			{
				configureCallback.Invoke(options);
			}

			return new Gadget(options);
		}
	}
}
