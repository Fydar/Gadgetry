using Gadgetry.Channels;
using Gadgetry.Documentation;

namespace Gadgetry.Samples.Samples;

internal class DocumentationSample
{
	#region create
	public static Gadget CreateGadget(
		out GadgetChannel<int> numbersChannel)
	{
		numbersChannel = new GadgetChannel<int>("numbers")
			.UseDocumentation(options =>
			{
				options.DisplayName = "Output Numbers";
				options.Description = "The destination for the generated numbers.";
			});

		return Gadget.Create()
			.UseDocumentation(options =>
			{
				options.DisplayName = "Counting Gadget";
				options.Description = "Writes numbers from 0 to 1000 to a channel.";
			})
			.Build("counting-gadget");
	}
	#endregion create
}
