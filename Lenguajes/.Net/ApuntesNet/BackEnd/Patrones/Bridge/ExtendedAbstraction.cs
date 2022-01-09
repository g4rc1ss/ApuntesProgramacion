﻿using Bridge.Implementacion;

namespace Bridge
{
    // You can extend the Abstraction without changing the Implementation
    // classes.
    internal class ExtendedAbstraction : Abstraction
    {
        public ExtendedAbstraction(IImplementation implementation) : base(implementation)
        {
        }

        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n" +
                _implementation.OperationImplementation();
        }
    }
}
