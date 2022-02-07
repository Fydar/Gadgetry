namespace Gadgetry.Channels;

/// <summary>
/// Static utilities for interacting with channels for a producer-consumer data model.
/// </summary>
public static class GadgetChannel
{
	/// <summary>
	/// Creates a new instance of the <see cref="GadgetChannel{TModel}"/> class with an associated identifier.
	/// </summary>
	/// <param name="identifier">An identifier for this <see cref="IGadgetChannel"/>.</param>
	public static GadgetChannel<TModel> Create<TModel>(string identifier)
	{
		return new GadgetChannel<TModel>(identifier);
	}
}

/// <summary>
/// Represents a hard-typed channel in a producer-consumer data model.
/// </summary>
public class GadgetChannel<TModel> : IGadgetChannel
{
	/// <summary>
	/// A collection of all <see cref="IGadgetChannelFeature"/> features associated with this <see cref="GadgetChannel{TModel}"/>.
	/// </summary>
	public IFeatureCollection<IGadgetChannelFeature> Features { get; } = new FeatureCollection<IGadgetChannelFeature>();

	/// <summary>
	/// An identifier for this <see cref="IGadgetChannel"/>.
	/// </summary>
	public string Identifier { get; }

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetChannel{TModel}"/> class with an associated identifier.
	/// </summary>
	/// <param name="identifier">An identifier for this <see cref="IGadgetChannel"/>.</param>
	internal GadgetChannel(string identifier)
	{
		Identifier = identifier;
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"'{Identifier}'";
	}
}
