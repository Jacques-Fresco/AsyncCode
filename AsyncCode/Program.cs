class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine($"Начало работы Main [{Thread.CurrentThread.ManagedThreadId}]");
        await callMethod();
        Console.WriteLine($"Завершаем работу Main [{Thread.CurrentThread.ManagedThreadId}]");
        Console.ReadKey();
    }

    public static async Task callMethod()
    {
        Console.WriteLine($"Начало работы callMethod [{Thread.CurrentThread.ManagedThreadId}]");
        Task<int> task = Method1();
        Console.WriteLine($"После Task<int> task = Method1(); [{Thread.CurrentThread.ManagedThreadId}]");
        Method2();
        Console.WriteLine($"До int count = await task; [{Thread.CurrentThread.ManagedThreadId}]");
        int count = await task;
        Console.WriteLine($"После int count = await task; [{Thread.CurrentThread.ManagedThreadId}]");
        Method3(count);
        Console.WriteLine($"Завершаем работу callMethod [{Thread.CurrentThread.ManagedThreadId}]");
    }

    public static async Task<int> Method1()
    {
        Console.WriteLine($"Начало работы Method1 [{Thread.CurrentThread.ManagedThreadId}]");
        int count = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($" Method 1 [{Thread.CurrentThread.ManagedThreadId}]");
                count += 1;
            }
        });
        Console.WriteLine($"Завершаем работу Method1 [{Thread.CurrentThread.ManagedThreadId}]");
        return count;
    }

    public static void Method2()
    {
        Console.WriteLine($"Начало работы Method2 [{Thread.CurrentThread.ManagedThreadId}]");
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine($" Method 2 [{Thread.CurrentThread.ManagedThreadId}]");
        }
        Console.WriteLine($"Завершаем работу Method2 [{Thread.CurrentThread.ManagedThreadId}]");
    }

    public static void Method3(int count)
    {
        Console.WriteLine($"Начало работы Method3 [{Thread.CurrentThread.ManagedThreadId}]");
        Console.WriteLine("Total count is " + count);
        Console.WriteLine($"Завершаем работу Method3 [{Thread.CurrentThread.ManagedThreadId}]");
    }
}