using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Resources
{
	public class ReadBlockingResource<TModel> : IResource<TModel>
	{
		private readonly TaskCompletionSource<TModel> completion;

		public ReadBlockingResourceKey<TModel> Key { get; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IResourceKey IResource.Key => Key;

		internal ReadBlockingResource(ReadBlockingResourceKey<TModel> key)
		{
			Key = key;
			completion = new TaskCompletionSource<TModel>();
		}

		public async ValueTask<TModel> ReadAsync(CancellationToken cancellationToken = default)
		{
			return await completion.Task;
		}

		public void SetResult(TModel model)
		{
			if (!completion.TrySetResult(model))
			{
				throw new InvalidOperationException($"Trying to set a result of a {nameof(ReadBlockingResource<TModel>)} that already has a value.");
			}
		}

		public override string ToString()
		{
			if (completion.Task.IsCompleted)
			{
				return $"{Key}: {completion.Task.Result}";
			}
			else
			{
				return $"{Key}: Pending...";
			}
		}
	}
}
