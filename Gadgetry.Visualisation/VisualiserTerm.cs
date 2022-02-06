namespace Gadgetry.Visualisation;

public class VisualiserTerm : IVisualiserData
{
	public string Name { get; }
	public string Colour { get; }

	internal VisualiserTerm(string name, string colour)
	{
		Name = name;
		Colour = colour;
	}
}
