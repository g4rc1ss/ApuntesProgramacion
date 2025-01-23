using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

using BenchmarkDotNet.Attributes;

namespace IntrinsicsVsNormalExecution;

[MemoryDiagnoser]
public class IntrinsicsVsNormalArm
{
    [Params(1, 10, 100, 1000, 100000, 1000000)]
    public int iterations;

    private int[]? paramA;
    private int[]? paramB;

    [GlobalSetup]
    public void Setup()
    {
        paramA = Enumerable.Range(0, iterations).ToArray();
        paramB = Enumerable.Range(0, iterations).ToArray();
    }

    [Benchmark]
    public unsafe void SumArraysWithIntrinsicsAndFixed()
    {
        var len = paramA.Length;
        var result = new int[len];

        fixed (int* paramAPtr = paramA, paramBPtr = paramB, resultPtr = result)
        {
            if (!AdvSimd.IsSupported)
            {
                throw new PlatformNotSupportedException();
            }

            for (var i = 0; i < len; i += Vector128<int>.Count)
            {
                var nextAPrt = i + paramAPtr;
                var nextBPrt = i + paramBPtr;
                var nextResultPtr = i + resultPtr;

                var vecA = Vector128.Load(nextAPrt);
                var vecB = Vector128.Load(nextBPrt);

                // Llamada al procesador
                var vecResult = AdvSimd.Add(vecA, vecB);

                vecResult.Store(nextResultPtr);
            }
        }
    }

    [Benchmark]
    public unsafe void SumArraysWithIntrinsicsWithMarshal()
    {
        var pointerA = Marshal.AllocHGlobal(sizeof(int) * paramA.Length);
        var pointerB = Marshal.AllocHGlobal(sizeof(int) * paramB.Length);
        var resultPointer = Marshal.AllocHGlobal(sizeof(int) * paramA.Length);
        var len = paramA.Length;

        try
        {
            if (!AdvSimd.IsSupported)
            {
                throw new PlatformNotSupportedException();
            }

            Marshal.Copy(paramA, 0, pointerA, len);
            Marshal.Copy(paramB, 0, pointerB, len);

            for (var i = 0; i < len; i += Vector128<int>.Count)
            {
                var nextAPrt = i + (int*)pointerA;
                var nextBPrt = (i + (int*)pointerB);
                var nextResultPtr = (i + (int*)resultPointer);

                var vecA = Vector128.Load(nextAPrt);
                var vecB = Vector128.Load(nextBPrt);

                // Llamada al procesador
                var vecResult = AdvSimd.Add(vecA, vecB);

                vecResult.Store(nextResultPtr);
            }
        }
        finally
        {
#if DEBUG
            for (int i = 0; i < len; i++)
            {
                var nextResultPtr = (i + (int*)resultPointer);
                Console.WriteLine(*nextResultPtr);
            }
#endif

            Marshal.FreeHGlobal(pointerA);
            Marshal.FreeHGlobal(pointerB);
            Marshal.FreeHGlobal(resultPointer);
        }
    }

    [Benchmark]
    public unsafe void SumArraysWithIntrinsicsWithMarshalWithoutCopy()
    {
        var resultPointer = Marshal.AllocHGlobal(sizeof(int) * paramA.Length);
        var len = paramA.Length;
        var resultPtr = (int*)resultPointer;

        try
        {
            if (!AdvSimd.IsSupported)
            {
                throw new PlatformNotSupportedException();
            }

            fixed (int* paramAPtr = paramA, paramBPtr = paramB)
            {
                for (var i = 0; i < len; i += Vector128<int>.Count)
                {
                    var nextAPrt = i + paramAPtr;
                    var nextBPrt = (i + paramBPtr);
                    var nextResultPtr = (i + resultPtr);

                    var vecA = Vector128.Load(nextAPrt);
                    var vecB = Vector128.Load(nextBPrt);

                    // Llamada al procesador
                    var vecResult = AdvSimd.Add(vecA, vecB);

                    vecResult.Store(nextResultPtr);
                }
            }
        }
        finally
        {
#if DEBUG
            for (int i = 0; i < len; i++)
            {
                var nextResultPtr = (i + (int*)resultPointer);
                Console.WriteLine(*nextResultPtr);
            }
#endif
            Marshal.FreeHGlobal(resultPointer);
        }
    }

    [Benchmark]
    public void SumArrays()
    {
        var result = new int[paramA.Length];

        for (var i = 0; i < paramA.Length; i++)
        {
            result[i] = paramA[i] + paramB[i];
        }
    }
}