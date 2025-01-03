using BenchmarkDotNet.Attributes;

namespace RecordVsClass;

[MemoryDiagnoser]
public class Bench
{
    [Benchmark]
    public void Record()
    {
        _ = new BenchmarkRecord("Hola", 1, 200);
    }

    [Benchmark]
    public void ModifyRecord()
    {
        var benchmarkRecord = new BenchmarkRecord("Hola", 1, 200);
        _ = benchmarkRecord with { X = "Adios", Y = 50 };
    }

    [Benchmark]
    public void CloneRecord()
    {
        var benchmarkRecord = new BenchmarkRecord("Hola", 1, 200);
        var cloned = benchmarkRecord with { };
    }

    [Benchmark]
    public void CreateRecordLoopList()
    {
        for (int i = 0; i < 100; i++)
        {
            _ = new BenchmarkRecord("Hola", 1, 200);
        }
    }

    [Benchmark]
    public void ModifyRecordLoopList()
    {
        for (int i = 0; i < 100; i++)
        {
            var benchmarkRecord = new BenchmarkRecord("Hola", 1, 200);
            _ = benchmarkRecord with { X = "Adios", Y = 50 };
        }
    }

    [Benchmark]
    public void CloneRecordLoopList()
    {
        for (int i = 0; i < 100; i++)
        {
            var benchmarkRecord = new BenchmarkRecord("Hola", 1, 200);
            var cloned = benchmarkRecord with { };
        }
    }

    [Benchmark]
    public void Classes()
    {
        _ = new BenchmarkClass { X = "Hola", Z = 200, Y = 1 };
    }

    [Benchmark]
    public void ModifyClass()
    {
        var benchmarkClass = new BenchmarkClass { X = "Hola", Z = 200, Y = 1 };
        benchmarkClass.X = "Adios";
        benchmarkClass.Y = 50;
    }

    [Benchmark]
    public void CloneClass()
    {
        var benchmarkClass = new BenchmarkClass { X = "Hola", Z = 200, Y = 1 };
        var cloned = new BenchmarkClass { X = benchmarkClass.X, Z = benchmarkClass.Z, Y = benchmarkClass.Y, };
    }

    [Benchmark]
    public void CreateClassLoopList()
    {
        for (int i = 0; i < 100; i++)
        {
            _ = new BenchmarkClass { X = "Hola", Z = 200, Y = 1 };
        }
    }

    [Benchmark]
    public void ModifyClassInLoop()
    {
        for (int i = 0; i < 100; i++)
        {
            var benchmarkClass = new BenchmarkClass { X = "Hola", Z = 200, Y = 1 };
            benchmarkClass.X = "Adios";
            benchmarkClass.Y = 50;
        }
    }

    [Benchmark]
    public void CloneClassInLoop()
    {
        for (int i = 0; i < 100; i++)
        {
            var benchmarkClass = new BenchmarkClass { X = "Hola", Z = 200, Y = 1 };
            var cloned = new BenchmarkClass { X = benchmarkClass.X, Z = benchmarkClass.Z, Y = benchmarkClass.Y, };
        }
    }
}