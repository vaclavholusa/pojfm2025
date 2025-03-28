namespace LifecyclesDemo;

public class GeneratorTransient
{
    public Guid Guid { get; private set; }

    public GeneratorTransient()
    {
        Guid = Guid.NewGuid();
    }
}
