namespace Adapter
{

    // The Adapter makes the Adaptee's interface compatible with the Target's
    // interface.
    internal class PatronAdapter : ITarget
    {
        private readonly Adaptar _adaptar;

        public PatronAdapter(Adaptar adaptar)
        {
            _adaptar = adaptar;
        }

        public string GetRequest()
        {
            return $"This is '{_adaptar.GetSpecificRequest()}'";
        }
    }
}
