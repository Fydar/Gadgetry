using Gadgetry.Tasks;
using Gadgetry.Workers;
using System;
using System.Threading.Tasks;

namespace Gadgetry.Samples.Samples;

internal class WorkerSample
{
	#region create
	public static Gadget CreateGadget()
	{
		return Gadget.Create()
			.UseWorker(Gadget.Create()
				.UseTask(async (gadgetRuntime, cancellationToken) =>
				{
					for (int i = 0; i < 10; i++)
					{
						await Task.Delay(100, cancellationToken);
						Console.WriteLine($"Worker progress: {i + 1}0%");
					}
				}),
				new GadgetWorkerOptions(16)
			)
			.Build("processing-gadget");
	}
	#endregion create
}
