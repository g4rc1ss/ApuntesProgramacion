﻿namespace Proxy;

// The Proxy has an interface identical to the RealSubject.
internal class PatronProxy(RealSubject realSubject) : ISubject
{
    // The most common applications of the Proxy pattern are lazy loading,
    // caching, controlling the access, logging, etc. A Proxy can perform
    // one of these things and then, depending on the result, pass the
    // execution to the same method in a linked RealSubject object.

    public void Request()
    {
        if (CheckAccess())
        {
            realSubject.Request();

            LogAccess();
        }
    }

    public bool CheckAccess()
    {
        // Some real checks should go here.
        Console.WriteLine("Proxy: Checking access prior to firing a real request.");

        return true;
    }

    public void LogAccess()
    {
        Console.WriteLine("Proxy: Logging the time of request.");
    }
}
