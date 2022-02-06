using Gadgetry.Tasks;
using Gadgetry.Visualisation;
using System.Threading.Tasks;

namespace Gadgetry.Samples.Samples;

internal class VisualisationSample
{
	#region create
	public static Gadget CreateGadget()
	{
		return Gadget.Create()
			.AddVisualiser(out var progressBar,
				VisualiserProgressBar.Create(
					Visualiser.SplitSeries(
						Visualiser.Term("Success", "green", out var progressSuccess),
						Visualiser.Term("Warning", "amber", out var progressWarning),
						Visualiser.Term("Error", "red", out var progressError)
					),
					out var progressCount)
			)
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				gadgetRuntime.SetTerm(progressCount, 50);
				gadgetRuntime.SetTerm(progressWarning, 5);
				gadgetRuntime.SetTerm(progressError, 3);

				for (int i = 0; i < 20; i++)
				{
					await Task.Delay(10, cancellationToken);

					gadgetRuntime.IncrementTerm(progressSuccess, 1.0);
				}
			})
			.Build("processing-gadget");
	}
	#endregion create
}
