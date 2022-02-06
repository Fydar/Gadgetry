using System;

namespace Gadgetry;

/// <summary>
/// A builder used to construct <see cref="Gadget"/> instances from the current state of the builder.
/// </summary>
public interface IGadgetBuilder
{
	/// <summary>
	/// Constructs a <see cref="Gadget"/> instance from the current state of this builder.
	/// </summary>
	/// <param name="identifier">An identifier for the newly constructed <see cref="Gadget"/>.</param>
	/// <returns>A <see cref="Gadget"/> constructed from the current state of this builder.</returns>
	Gadget Build(
		string identifier);

	/// <summary>
	/// Invoked to configure the current state of the builder.
	/// </summary>
	/// <param name="options">Options used to configure the constructed <see cref="Gadget"/>.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
	IGadgetBuilder Configure(
		Action<GadgetOptions> options);
}
