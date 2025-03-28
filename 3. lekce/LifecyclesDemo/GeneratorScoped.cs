namespace LifecyclesDemo;

public class GeneratorScoped
{
    public Guid Guid { get; private set; }

    public GeneratorScoped()
    {
        Guid = Guid.NewGuid();
    }
    
}
