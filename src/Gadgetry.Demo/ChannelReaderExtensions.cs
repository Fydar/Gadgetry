using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;

namespace Gadgetry;

public static class ChannelReaderExtensions
{
	public static async IAsyncEnumerable<T[]> ReadInBatchesAsync<T>(
		this ChannelReader<T> channelReader,
		int batchSize,
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		var items = new List<T>(batchSize);
		await foreach (var item in channelReader.ReadAllAsync(cancellationToken))
		{
			items.Add(item);

			if (items.Count >= batchSize)
			{
				yield return items.ToArray();
				items.Clear();
			}
		}
		if (items.Count > 0)
		{
			yield return items.ToArray();
		}
	}
}
