using Gadgetry.Internal;

namespace Gadgetry;

/// <summary>
/// A highly configurable abstraction representing a <b>long-running</b> task or <b>background worker</b>.
/// </summary>
/// <remarks>
/// Instances of <see cref="Gadget"/> are constructed via the <see cref="Create"/> method.
/// </remarks>
public class Gadget
{
	/// <summary>
	/// An identifier for this <see cref="Gadget"/>.
	/// </summary>
	public string Identifier { get; }

	/// <summary>
	/// A collection of all <see cref="IGadgetFeature"/> features associated with this <see cref="Gadget"/>.
	/// </summary>
	public IReadOnlyFeatureCollection<IGadgetFeature> Features { get; }

	internal Gadget(GadgetOptions options)
	{
		Identifier = options.Identifier;
		Features = options.Features;
	}

	/// <summary>
	/// Creates a <see cref="GadgetRuntime"/> to execute the behaviour associated with this <see cref="Gadget"/>.
	/// </summary>
	/// <returns>A <see cref="GadgetRuntime"/> configured to execute the behaviour associated with this <see cref="Gadget"/>.</returns>
	public GadgetRuntime CreateRunner()
	{
		return new GadgetRuntime(this);
	}

	/// <summary>
	/// Begins construction of a <see cref="Gadget"/> via an <see cref="IGadgetBuilder"/>.
	/// </summary>
	/// <returns>An <see cref="IGadgetBuilder"/> used to construct a <see cref="Gadget"/>.</returns>
	public static IGadgetBuilder Create()
	{
		return new GadgetBuilder();
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"Gadget({Identifier})";
	}
}
