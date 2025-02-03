using System.Net;
using System.Threading.RateLimiting;

using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = (int)HttpStatusCode.TooManyRequests;
    options.AddConcurrencyLimiter(policyName: "limiter", limiterOpt =>
    {
        limiterOpt.PermitLimit = 10;
        limiterOpt.QueueLimit = 20;
        limiterOpt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRateLimiter();
app.UseHttpsRedirection();

app.MapGet("/normalRequest", (ILogger<Program> logger) =>
    {
        ThreadPool.GetAvailableThreads(out var workerThreads, out var iocpThreads);
        Console.WriteLine($"WorkerThreads: {workerThreads}, IOCPThreads: {iocpThreads}");
    })
    .WithName("normalRequest")
    .WithOpenApi();

app.MapGet("/blockRequest", (ILogger<Program> logger) =>
    {
        ThreadPool.GetAvailableThreads(out var workerThreads, out var iocpThreads);
        Console.WriteLine($"WorkerThreads: {workerThreads}, IOCPThreads: {iocpThreads}");

        Thread.Sleep(TimeSpan.FromHours(10));
    })
    .RequireRateLimiting("limiter")
    .WithName("blockrequest")
    .WithOpenApi();

app.MapGet("/nonBlockRequest", async (ILogger<Program> logger) =>
    {
        ThreadPool.GetAvailableThreads(out var workerThreads, out var iocpThreads);
        Console.WriteLine($"WorkerThreads: {workerThreads}, IOCPThreads: {iocpThreads}");

        await Task.Delay(TimeSpan.FromSeconds(10));
    })
    .WithName("nonBlockRequest")
    .WithOpenApi();


ThreadPool.SetMaxThreads(20, 20);
ThreadPool.GetAvailableThreads(out var workerThreads, out var iocpThreads);
Console.WriteLine($"WorkerThreads: {workerThreads} \n" +
                  $"IOCPThreads: {iocpThreads}");

await app.RunAsync();