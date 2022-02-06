using Gadgetry.Tasks;
using System;
using System.Threading.Tasks;

namespace Gadgetry.Samples.Samples;

internal class TaskSample
{
	#region create
	public static Gadget CreateGadget()
	{
		return Gadget.Create()
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				await Task.Delay(1000, cancellationToken);
				Console.WriteLine($"Gadget completed execution");
			})
			.Build("processing-gadget");
	}
	#endregion create
}
