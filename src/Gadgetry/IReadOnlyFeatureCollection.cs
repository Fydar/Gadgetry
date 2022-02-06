using System.Collections.Generic;

namespace Gadgetry;

/// <summary>
/// A <b>read-only</b> collection of features.
/// </summary>
public interface IReadOnlyFeatureCollection<TFeature> : IReadOnlyCollection<TFeature>
	where TFeature : class, IFeature
{
	/// <summary>
	/// Enumerates all features of a type contained within this collection.
	/// </summary>
	/// <typeparam name="TType">The type of feature to find.</typeparam>
	/// <returns>All features which match the supplied <typeparamref name="TType"/>.</returns>
	IEnumerable<TType> GetAllFeatures<TType>()
		where TType : class, TFeature;

	/// <summary>
	/// Retrieves the first feature of a type contained within this collection.
	/// </summary>
	/// <typeparam name="TType">The type of feature to find.</typeparam>
	/// <returns>If a feature is found, returns a feature that match the supplied <typeparamref name="TType"/>; otherwise <c>null</c>.</returns>
	TType? GetFeature<TType>()
		where TType : class, TFeature;
}
