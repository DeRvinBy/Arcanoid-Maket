namespace MyLibrary.Prototype
{
    public interface IPrototype<T>
    {
        T GetCopy();
    }
}