using Cachear.Distributed;
using Cachear.Memory;


new MemoryCaching().MemoryCacheWithDI();

await new DistributedMemory().DistributedMemoryWithDIAsync();
await new DistributedRedis().DistributedRedisAsync();


Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
