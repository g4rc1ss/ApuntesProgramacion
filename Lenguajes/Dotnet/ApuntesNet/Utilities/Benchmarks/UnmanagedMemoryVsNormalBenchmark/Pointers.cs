using BenchmarkDotNet.Attributes;

namespace UnmanagedMemoryVsNormalBenchmark;

[MemoryDiagnoser]
public class Pointers
{
    private readonly int[] _dataMock = Enumerable.Range(0, 1000).ToArray();


    [Benchmark]
    public unsafe void ModifyArrayDataWithPointers()
    {
        fixed (int* ptr = _dataMock)
        {
            for (var i = 0; i < 1000; i++)
            {
                *(ptr + i) = i;
            }
        }
    }

    [Benchmark]
    public void ModifyArrayData()
    {
        for (var i = 0; i < _dataMock.Length; i++)
        {
            _dataMock[i] = i;
        }
    }
}