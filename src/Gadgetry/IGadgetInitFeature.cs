namespace Gadgetry;

/// <summary>
/// A feature that controls the <b>"initialisation"</b> behaviour of a <see cref="GadgetRuntime"/>.
/// </summary>
public interface IGadgetInitFeature : IGadgetFeature
{
	/// <summary>
	/// Invoked during the <b>"initialisation"</b> of a <see cref="GadgetRuntime"/>.
	/// </summary>
	/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> that is being executed.</param>
	void Init(
		GadgetRuntime gadgetRuntime);
}
