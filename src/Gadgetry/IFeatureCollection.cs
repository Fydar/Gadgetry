using System;

namespace Gadgetry;

/// <summary>
/// A mutatable collection of features.
/// </summary>
public interface IFeatureCollection<TFeature> : IReadOnlyFeatureCollection<TFeature>
	where TFeature : class, IFeature
{
	/// <summary>
	/// Attempts to retrieves the first feature of a type contained within this collection, and creates one if none where found.
	/// </summary>
	/// <typeparam name="TType">The type of feature to find.</typeparam>
	/// <returns>If a feature is found, returns a feature that match the supplied <typeparamref name="TType"/>; otherwise a <c>new</c> instance is created and returned.</returns>
	TType GetOrCreateFeature<TType>()
		where TType : class, TFeature, new();

	/// <summary>
	/// Attempts to retrieves the first feature of a type contained within this collection, and creates one from a <paramref name="factory"/> if none where found.
	/// </summary>
	/// <typeparam name="TType">The type of feature to find.</typeparam>
	/// <returns>If a feature is found, returns a feature that match the supplied <typeparamref name="TType"/>; otherwise the <paramref name="factory"/> result..</returns>
	TType GetOrCreateFeature<TType>(Func<TType> factory)
		where TType : class, TFeature;
}
