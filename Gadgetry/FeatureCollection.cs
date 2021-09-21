using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry
{
	[DebuggerDisplay("Count = {Count,nq}")]
	[DebuggerTypeProxy(typeof(FeatureCollection<>.FeatureCollectionDebugView))]
	public class FeatureCollection<TFeature> : IFeatureCollection<TFeature>
		where TFeature : class, IFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly List<TFeature> features;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Count => features.Count;

		internal FeatureCollection()
		{
			features = new List<TFeature>();
		}

		public T? GetFeature<T>()
			where T : class, TFeature
		{
			var getFeatureType = typeof(T);
			foreach (object? feature in features)
			{
				var featureType = feature.GetType();
				if (getFeatureType.IsAssignableFrom(featureType))
				{
					return (T)feature;
				}
			}
			return null;
		}

		public IEnumerable<T> GetAllFeatures<T>()
			where T : class, TFeature
		{
			var getFeatureType = typeof(T);
			foreach (var feature in features)
			{
				var featureType = feature.GetType();
				if (getFeatureType.IsAssignableFrom(featureType))
				{
					yield return (T)feature;
				}
			}
		}

		public T GetOrCreateFeature<T>()
			where T : class, TFeature, new()
		{
			var feature = GetFeature<T>();

			if (feature == null)
			{
				feature = new T();
				features.Add(feature);
			}
			return feature;
		}

		public T GetOrCreateFeature<T>(Func<T> factory)
			where T : class, TFeature
		{
			var feature = GetFeature<T>();

			if (feature == null)
			{
				feature = factory.Invoke();
				features.Add(feature);
			}
			return feature;
		}

		public IEnumerator<TFeature> GetEnumerator()
		{
			return features.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return features.GetEnumerator();
		}

		private class FeatureCollectionDebugView
		{
			[DebuggerDisplay("{Feature}", Name = "{Key,nq}", TargetTypeName = "{Type,nq}", Type = "{Type,nq}")]
			internal struct FeatureDebugView
			{
				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				public string Key;

				[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
				public TFeature Feature;

				[DebuggerBrowsable(DebuggerBrowsableState.Never)]
				public string Type;

				public FeatureDebugView(TFeature feature)
				{
					Type = feature.GetType().Name;
					Key = Type;
					Feature = feature;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private readonly FeatureCollection<TFeature> source;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public FeatureDebugView[] Features
			{
				get
				{
					var featuresDebugView = new FeatureDebugView[source.features.Count];
					for (int i = 0; i < featuresDebugView.Length; i++)
					{
						featuresDebugView[i] = new FeatureDebugView(source.features[i]);
					}
					return featuresDebugView;
				}
			}

			public FeatureCollectionDebugView(FeatureCollection<TFeature> source)
			{
				this.source = source;
			}
		}
	}
}
