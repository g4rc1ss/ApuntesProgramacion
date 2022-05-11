﻿using Decorator.ClasesBase;

namespace Decorator
{
    // Decorators can execute their behavior either before or after the call to
    // a wrapped object.
    internal class ConcreteDecoratorB : PatronDecorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }
}
