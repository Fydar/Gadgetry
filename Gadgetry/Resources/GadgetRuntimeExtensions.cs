using System;

namespace Gadgetry.Resources;

public static class GadgetRuntimeExtensions
{
	public static IResource<TModel> Require<TModel>(
		this GadgetRuntime gadgetRuntime,
		IResourceKey<TModel> resource)
	{
		if (resource is AutoInitialisedResourceKey<TModel> autoInitialised)
		{
			return gadgetRuntime.Require(autoInitialised);
		}
		else if (resource is ReadBlockingResourceKey<TModel> blocking)
		{
			return gadgetRuntime.Require(blocking);
		}
		else
		{
			throw new InvalidOperationException($"Unable to handle resource of type '{resource.GetType()}'.");
		}
	}

	public static AutoInitialisedResource<TModel> Require<TModel>(
		this GadgetRuntime gadgetRuntime,
		AutoInitialisedResourceKey<TModel> resource)
	{
		var stateChannelsFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateResourcesFeature>();

		return stateChannelsFeature.GetOrCreateResource(
			resource,
			() => new AutoInitialisedResource<TModel>(gadgetRuntime, resource));
	}

	public static ReadBlockingResource<TModel> Require<TModel>(
		this GadgetRuntime gadgetRuntime,
		ReadBlockingResourceKey<TModel> resource)
	{
		var stateChannelsFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateResourcesFeature>();

		return stateChannelsFeature.GetOrCreateResource(
			resource,
			() => new ReadBlockingResource<TModel>(resource));
	}
}
