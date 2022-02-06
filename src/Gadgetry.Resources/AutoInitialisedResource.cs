using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Resources;

public class AutoInitialisedResource<TModel> : IResource<TModel>
{
	private readonly Task<TModel> factoryTask;

	public AutoInitialisedResourceKey<TModel> Key { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IResourceKey IResource.Key => Key;

	internal AutoInitialisedResource(
		GadgetRuntime modularTask,
		AutoInitialisedResourceKey<TModel> key)
	{
		Key = key;

		factoryTask = key.factory.Invoke(modularTask);
	}

	public Task<TModel> ReadAsync(CancellationToken cancellationToken = default)
	{
		return factoryTask;
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		if (factoryTask.IsCompleted)
		{
			return $"{Key}: {factoryTask.Result}";
		}
		else
		{
			return $"{Key}: Pending...";
		}
	}
}
