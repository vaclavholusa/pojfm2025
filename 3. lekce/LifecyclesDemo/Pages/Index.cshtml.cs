using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifecyclesDemo.Pages;

public class IndexModel(GeneratorScoped guidGeneratorScoped, 
                        GeneratorScoped guidGeneratorScoped2, 
                        GeneratorSingleton guidGeneratorSingleton, 
                        GeneratorSingleton guidGeneratorSingleton2, 
                        GeneratorTransient guidGeneratorTransient,
                        GeneratorTransient guidGeneratorTransient2
    ) : PageModel
{
    public Guid GuidScoped => guidGeneratorScoped.Guid;
    public Guid GuidScoped2 => guidGeneratorScoped2.Guid;
    public Guid GuidTransient => guidGeneratorTransient.Guid;
    public Guid GuidTransient2 => guidGeneratorTransient2.Guid;
    public Guid GuidSingleton => guidGeneratorSingleton.Guid;
    public Guid GuidSingleton2 => guidGeneratorSingleton2.Guid;

    public void OnGet()
    {

    }
}
