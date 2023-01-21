namespace Command
{
    // Some commands can implement simple operations on their own.
    internal class SimpleCommand : ICommand
    {
        private readonly string _payload = string.Empty;

        public SimpleCommand(string payload)
        {
            _payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({_payload})");
        }
    }
}
