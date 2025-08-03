using System.Collections.Concurrent;

namespace SportsProductApi.Helpers
{
    // Product Id Generator
    public static class ProductIdGenerator
    {
        private static readonly ConcurrentDictionary<string, byte> UsedIds = new();
        private static readonly Random _random = new();

        public static string GenerateUniqueId()
        {
            string id;
            do
            {
                id = _random.Next(100000, 999999).ToString();
            } while (!UsedIds.TryAdd(id, 0));
            return id;
        }
    }
}
