using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddTransient<ClassA>();
services.AddTransient<ClassB>();
services.AddTransient<ClassC>();

var provider = services.BuildServiceProvider();

var a = provider.GetRequiredService<ClassA>();
a.Hello();

class ClassA(ClassB b)
{
    public void Hello()
    {
        Console.WriteLine("Hello");
        b.World();
    }
}

class ClassB(ClassC c)
{
    public void World()
    {
        Console.WriteLine("World");
        c.Exclamation();
    }
}

class ClassC
{
    public void Exclamation()
    {
       Console.WriteLine("!");
    }
}