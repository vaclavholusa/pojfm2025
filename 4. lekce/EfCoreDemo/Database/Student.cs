namespace EfCoreDemo.Database;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool HasSnack { get; set; }

    public List<Lecture> Lectures { get; set; }
}
