namespace Flyweight
{
    internal static class FlyweightCache
    {
        private static readonly Dictionary<string, object> _cache = new();

        public static bool TryGetValue(string id, out object value)
        {
            return _cache.TryGetValue(id, out value);
        }

        public static bool TryGetValue<T>(string id, out T value)
        {
            var hasValue = _cache.TryGetValue(id, out var objectValue);
            value = (T)objectValue;
            return hasValue;
        }

        public static void SetValue(string id, object value)
        {
            _cache.Add(id, value);
        }
    }
}
