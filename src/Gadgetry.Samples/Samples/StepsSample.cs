using Gadgetry.Steps;
using Gadgetry.Tasks;
using System;
using System.Threading.Tasks;

namespace Gadgetry.Samples.Samples;

internal class StepsSample
{
	#region create
	public static Gadget CreateGadget()
	{
		return Gadget.Create()
			.UseStep(Gadget.Create()
				.UseTask(async (gadgetRuntime, cancellationToken) =>
				{
					Console.WriteLine("Started Step 1");
					await Task.Delay(1000, cancellationToken);
					Console.WriteLine("Completed Step 1");
				})
			)
			.UseStep(Gadget.Create()
				.UseTask(async (gadgetRuntime, cancellationToken) =>
				{
					Console.WriteLine("Started Step 2");
					await Task.Delay(1000, cancellationToken);
					Console.WriteLine("Completed Step 2");
				})
			)
			.Build("processing-gadget");
	}
	#endregion create
}
