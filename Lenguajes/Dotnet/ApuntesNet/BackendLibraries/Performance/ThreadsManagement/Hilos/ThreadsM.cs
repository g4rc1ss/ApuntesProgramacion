namespace ThreadsManagement.Hilos;

public static class ThreadsM
{
    public static Thread StartThread()
    {
        var thread = new Thread(() =>
        {
            for (var x = 0; x < 1000; x++)
            {
                Console.WriteLine("hilo1");
            }
        });

        thread.Start();

        return thread;
    }

    public static void WaitThread(Thread thread)
    {
        thread.Join();
    }
}