﻿namespace Strategy;

// The Context defines the interface of interest to clients.
internal class Context
{
    // The Context maintains a reference to one of the Strategy objects. The
    // Context does not know the concrete class of a strategy. It should
    // work with all strategies via the Strategy interface.
    private IStrategy? strategy;

    public Context()
    { }

    // Usually, the Context accepts a strategy through the constructor, but
    // also provides a setter to change it at runtime.
    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    // Usually, the Context allows replacing a Strategy object at runtime.
    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    // The Context delegates some work to the Strategy object instead of
    // implementing multiple versions of the algorithm on its own.
    public void DoSomeBusinessLogic()
    {
        Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
        object? result = strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

        string? resultStr = string.Empty;
        foreach (string? element in result as List<string>)
        {
            resultStr += element + ",";
        }

        Console.WriteLine(resultStr);
    }
}
