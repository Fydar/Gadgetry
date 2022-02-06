using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gadgetry
{
	[DebuggerDisplay("Count = {Count,nq}")]
	[DebuggerTypeProxy(typeof(FeatureCollection<>.FeatureCollectionDebugView))]
	public class FeatureCollection<TFeature> : IFeatureCollection<TFeature>
		where TFeature : class, IFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Mutex mutex = new();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly ConcurrentBag<TFeature> features;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Count => features.Count;

		internal FeatureCollection()
		{
			features = new ConcurrentBag<TFeature>();
		}

		public T? GetFeature<T>()
			where T : class, TFeature
		{
			mutex.WaitOne();
			var getFeatureType = typeof(T);
			foreach (object? feature in features)
			{
				var featureType = feature.GetType();
				if (getFeatureType.IsAssignableFrom(featureType))
				{
					mutex.ReleaseMutex();
					return (T)feature;
				}
			}
			mutex.ReleaseMutex();
			return null;
		}

		public IEnumerable<T> GetAllFeatures<T>()
			where T : class, TFeature
		{
			mutex.WaitOne();
			var foundFeatures = new List<T>();
			var getFeatureType = typeof(T);
			foreach (var feature in features)
			{
				var featureType = feature.GetType();
				if (getFeatureType.IsAssignableFrom(featureType))
				{
					foundFeatures.Add((T)feature);
				}
			}
			mutex.ReleaseMutex();
			return foundFeatures;
		}

		public T GetOrCreateFeature<T>()
			where T : class, TFeature, new()
		{
			mutex.WaitOne();
			var feature = GetFeature<T>();

			if (feature == null)
			{
				feature = new T();
				features.Add(feature);
			}
			mutex.ReleaseMutex();
			return feature;
		}

		public T GetOrCreateFeature<T>(Func<T> factory)
			where T : class, TFeature
		{
			mutex.WaitOne();
			var feature = GetFeature<T>();

			if (feature == null)
			{
				feature = factory.Invoke();
				features.Add(feature);
			}
			mutex.ReleaseMutex();
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
					var rows = new List<FeatureDebugView>(source.features.Count);
					foreach (var feature in source.features)
					{
						rows.Add(new FeatureDebugView(feature));
					}
					return rows.ToArray();
				}
			}

			public FeatureCollectionDebugView(FeatureCollection<TFeature> source)
			{
				this.source = source;
			}
		}
	}
}
