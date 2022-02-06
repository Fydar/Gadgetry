using Fydar.Samples;
using Fydar.Samples.Formatting;
using Fydar.Samples.Formatting.CSharpFormatting;
using Fydar.Samples.Formatting.JsonFormatting;
using Fydar.Samples.Rendering.Svg;
using System.Threading.Tasks;

namespace Gadgetry.Samples;

internal class Program
{
	private static async Task Main(string[] args)
	{
		var sampleProject = SampleProject.Create()
			.AddFormattedSamples(options =>
			{
				options.AddSource(new FileSystemSource("Samples"));
				options.AddSource(new SampleReturnSampleSource(typeof(Program).Assembly));

				options.AddFormatter(new CSharpSampleFormatter());
				options.AddFormatter(new JsonSampleFormatter());
			})
			.RenderTo(new SvgSampleRenderer())
			.Build();

		await sampleProject.GenerateSamplesAsync("output");
	}
}
