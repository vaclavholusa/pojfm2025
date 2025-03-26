using System.Diagnostics;

var rnd = new Random();

var sw = Stopwatch.StartNew();
await Sequentuall();
Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");
Console.WriteLine();

sw.Restart();
await Parallel();
Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");


///
/// Tady neawaitujeme, takže se všechny tasky spustí najednou a počkáme na konci až se všechny dokončí
/// Každé tedy běží v samostatném vlákně a zpracování je mnohem rychlejší
///
async Task Parallel()
{
    Console.WriteLine($"Parallel");
    Console.WriteLine($"========");

    var task1 = GetMessage("Hello");
    var task2 = GetMessage("World");
    var task3 = GetMessage("From");
    var task4 = GetMessage("Async");
    var task5 = GetMessage("Programming");

    var results = await Task.WhenAll(task1, task2, task3, task4, task5);

    foreach (var result in results)
    {
        Console.WriteLine($"{result.Time}ms : {result.Message}");
    }

    Console.WriteLine($"Sum: {results.Sum(r => r.Time)}ms");
}

///
/// Tady awaitujeme každé volání metody GetMessage, takže se spustí postupně a vždy počkáme na dokončení
/// Naštěstí ale používáme neblokující čekání, takže neplýtváme vlákny
///
async Task Sequentuall()
{
    Console.WriteLine($"Sequentual");
    Console.WriteLine($"==========");

    var results = new List<(int Time, string Message)>();

    results.Add(await GetMessage("Hello"));
    results.Add(await GetMessage("World"));
    results.Add(await GetMessage("From"));
    results.Add(await GetMessage("Async"));
    results.Add(await GetMessage("Programming"));


    foreach (var result in results)
    {
        Console.WriteLine($"{result.Time}ms : {result.Message}");
    }

    Console.WriteLine($"Sum: {results.Sum(r => r.Time)}ms");
}


async Task<(int Time, string Message)> GetMessage(string msg)
{
    var wait = rnd.Next(500, 5000);
    await Task.Delay(wait);
    return (wait, msg);
}