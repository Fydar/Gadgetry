using System;

namespace Gadgetry;

public interface IGadgetBuilder
{
	Gadget Build(string identifier);
	IGadgetBuilder Configure(Action<GadgetOptions> options);
}
