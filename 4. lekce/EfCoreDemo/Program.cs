using EfCoreDemo.Database;
using Microsoft.EntityFrameworkCore;

//FillData();
//AssignStudentsToLectures();
OutputData();

void OutputData()
{
    using (var ctx = new AppDbContext())
    {
        var students = ctx.Students.Include(s => s.Lectures).ToList();
        foreach(var student in students)
        {
            Console.WriteLine($"{student.Name}, navštěvuje předměty");

            foreach(var lecture in student.Lectures)
            {
                Console.WriteLine($"     {lecture.Name}, který navštěvuje celkem {lecture.Students.Count} studentů");
            }
        }
    }
}

void AssignStudentsToLectures()
{
    using (var ctx = new AppDbContext())
    {
        var students = ctx.Students.ToList();
        var lectures = ctx.Lectures.ToList();

        // jsem svině :-)
        var snackAllowedLectures = lectures.Where(l => l.AllowsSnacks == true).ToList();
        var snackNotAllowedLectures = lectures.Where(l => l.AllowsSnacks == false).ToList();

        foreach (var student in students)
        {
            student.Lectures = student.HasSnack 
                ? snackNotAllowedLectures 
                : snackAllowedLectures;
        }

        ctx.SaveChanges();
    }
}

void FillData()
{
    using (var ctx = new AppDbContext())
    {
        for(int i = 0; i < 20; i++)
        {
            bool hasSnack = i % 3 == 0;
            string hasSnackStr = hasSnack ? "má" : "nemá";
            ctx.Students.Add(new Student
            {
                Name = $"Student č. {i}, který {hasSnackStr} svačinu",
                HasSnack = hasSnack
            });
        }

        for (int i = 0; i < 10; i++)
        {
            bool doesntAllowSnack = i % 3 == 0;
            string doesntAllowSnackStr = doesntAllowSnack ? "nepovoluje" : "povoluje";
            ctx.Lectures.Add(new Lecture
            {
                Name = $"Předmět č. {i}, který {doesntAllowSnackStr} svačinu",
                AllowsSnacks = !doesntAllowSnack
            });
        }

        ctx.SaveChanges();
    }
}

Console.WriteLine("");
