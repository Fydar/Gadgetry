namespace Gadgetry.Resources;

public interface IResourceKey
{
}

public interface IResourceKey<out TModel> : IResourceKey
{
}
