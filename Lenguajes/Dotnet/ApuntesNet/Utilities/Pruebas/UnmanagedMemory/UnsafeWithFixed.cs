namespace UnmanagedMemory;

public static class UnsafeWithFixed
{
    public static void Execute()
    {
        unsafe
        {
            var numbers = new int[1000000];
            fixed (int* ptr = numbers)
            {
                for (var i = 0; i < numbers.Length; i++)
                {
                    ptr[i] = 1 * sizeof(int);
                }

                for (var i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"{ptr[i]}");
                }
            }
        }
    }
}