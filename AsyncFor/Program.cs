using Nito.AsyncEx;
class Program
{
    static void Main(string[] args)
    {
        AsyncContext.Run(() => MainAsync(args));
    }
    public static async Task TestAsync()
    {
        Console.WriteLine($"T1");
        Thread.Sleep(1000);
        Console.WriteLine($"T2");
        await Task.Delay(1000);
        Console.WriteLine($"T3");
    }

    public static async void MainAsync(string[] args)
    {
        Func<int, Task> process = x =>
        {
            Console.WriteLine($"End processing {x}");
            return Task.CompletedTask;
        };
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        Parallel.ForEach(array, arr =>
        {
            process(arr);
        });
        /* foreach(int x in array)
             await process(x);*/
        Console.WriteLine($"M2");
    }
}