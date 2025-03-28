namespace LifecyclesDemo;

public class GeneratorSingleton
{
    public Guid Guid { get; private set; }

    public GeneratorSingleton()
    {
        Guid = Guid.NewGuid();
    }
}
