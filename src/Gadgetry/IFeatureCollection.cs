using System;

namespace Gadgetry;

public interface IFeatureCollection<TFeature> : IReadOnlyFeatureCollection<TFeature>
	where TFeature : class, IFeature
{
	T GetOrCreateFeature<T>() where T : class, TFeature, new();
	T GetOrCreateFeature<T>(Func<T> factory) where T : class, TFeature;
}
