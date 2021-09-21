using System.Collections.Generic;

namespace Gadgetry
{
	public interface IReadOnlyFeatureCollection<TFeature> : IReadOnlyCollection<TFeature>
		where TFeature : class, IFeature
	{
		IEnumerable<T> GetAllFeatures<T>() where T : class, TFeature;
		T? GetFeature<T>() where T : class, TFeature;
	}
}
