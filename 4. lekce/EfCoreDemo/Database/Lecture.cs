namespace EfCoreDemo.Database;

public class Lecture
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool AllowsSnacks { get; set; }

    public List<Student> Students { get; set; }
}
