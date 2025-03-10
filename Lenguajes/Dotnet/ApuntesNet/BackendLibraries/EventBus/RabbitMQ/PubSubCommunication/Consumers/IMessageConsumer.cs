﻿
namespace PubSubCommunication.Consumers;

public interface IMessageConsumer : IDisposable
{
    Task StartAsync(CancellationToken cancellationToken = default);
}

public interface IMessageConsumer<T> : IMessageConsumer
{

}
