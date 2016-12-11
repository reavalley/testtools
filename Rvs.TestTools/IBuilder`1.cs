namespace Rvs.TestTools
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
