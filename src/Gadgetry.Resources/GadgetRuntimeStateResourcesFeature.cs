using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gadgetry.Resources;

/// <summary>
/// A feature used to interact with the <b>resources</b> associated with an <see cref="GadgetRuntimeState"/>.
/// </summary>
public class GadgetRuntimeStateResourcesFeature : IGadgetRuntimeStateFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<IResource> resources = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Mutex mutex = new();

	public IReadOnlyList<IResource> Resources => resources;

	public TResource GetOrCreateResource<TResource>(
		IResourceKey resourceKey,
		Func<TResource> factory)
		where TResource : IResource
	{
		mutex.WaitOne();

		foreach (var resource in resources)
		{
			if (resource.Key == resourceKey)
			{
				mutex.ReleaseMutex();
				return (TResource)resource;
			}
		}

		var newResource = factory.Invoke();
		resources.Add(newResource);

		mutex.ReleaseMutex();
		return newResource;
	}
}
