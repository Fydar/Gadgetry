using Gadgetry.Resources;
using Gadgetry.Tasks;
using System.Threading.Tasks;

namespace Gadgetry.Samples.Samples;

internal class ResourcesSample
{
	#region create
	public static Gadget CreateGadget(
		out IResourceKey<string> responseResourceKey)
	{
		var responseReadBlockingResourceKey = ResourceKey.ReadBlocking<string>();
		responseResourceKey = responseReadBlockingResourceKey;

		return Gadget.Create()
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				await Task.Delay(1000, cancellationToken);

				var responseResource = gadgetRuntime.Require(responseReadBlockingResourceKey);
				responseResource.SetResult("Resource has been wrote to!");
			})
			.Build("processing-gadget");
	}
	#endregion create
}
