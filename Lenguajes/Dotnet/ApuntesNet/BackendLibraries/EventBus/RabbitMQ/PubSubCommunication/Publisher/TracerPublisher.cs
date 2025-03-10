﻿using System.Diagnostics;

using PubSubCommunication.Messages;

namespace PubSubCommunication.Publisher;

public static class TracerPublisher
{
    public static void TracePublishTags(Activity? activity, string? routingKey, Metadata calculatedMetadata, IMessage message)
    {
        activity?.SetTag("Message Name", message.Name);
        activity?.SetTag("Message Identifier", message.MessageIdentifier);
        activity?.SetTag("RoutingKey", routingKey);
        activity?.SetTag("Metadata CorrelationId", calculatedMetadata.CorrelationId);
        activity?.SetTag("Metadata CreatedUTC", calculatedMetadata.CreatedUtc);

    }
}
