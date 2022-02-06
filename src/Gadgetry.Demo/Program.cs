using System.Threading.Tasks;

namespace Gadgetry.Demo;

internal class Program
{
	private static async Task Main(string[] args)
	{
		var task = CounterSample.CreateCounterSample();

		var runner = task.CreateRunner();

		await runner.RunAsync();
	}
}
