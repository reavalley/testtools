namespace Rvs.TestTools
{
    public static class Builder
    {
        public static BuilderComponent<T> For<T>() where T : class
        {
            return new BuilderComponent<T>();
        }
    }
}