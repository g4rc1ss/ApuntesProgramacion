namespace Command
{
    // However, some commands can delegate more complex operations to other
    // objects, called "receivers."
    internal class ComplexCommand : ICommand
    {
        private readonly Receiver _receiver;

        // Context data, required for launching the receiver's methods.
        private readonly string _a;

        private readonly string _b;

        // Complex commands can accept one or several receiver objects along
        // with any context data via the constructor.
        public ComplexCommand(Receiver receiver, string a, string b)
        {
            _receiver = receiver;
            _a = a;
            _b = b;
        }

        // Commands can delegate to any methods of a receiver.
        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            _receiver.DoSomething(_a);
            _receiver.DoSomethingElse(_b);
        }
    }
}
