using Bogus;
using SupabaseMockData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupabaseMockData
{
    public class MockDataGenerator
    {
        public static async Task PopulateItems(SupabaseClient client)
        {
            // Predefined organizations and their associated database IDs
            var organizations = new Dictionary<string, List<string>>
            {
                { "Org1", new List<string> { "1234567890123456", "2345678901234567", "3456789012345678" } },
                { "Org2", new List<string> { "4567890123456789", "5678901234567890" } },
                { "Org3", new List<string> { "6789012345678901", "7890123456789012", "8901234567890123" } },
                { "Org4", new List<string> { "9012345678901234", "0123456789012345" } },
                { "Org5", new List<string> { "1122334455667788", "2233445566778899", "3344556677889900" } },
                { "Org6", new List<string> { "4455667788990011", "5566778899001122" } },
                { "Org7", new List<string> { "6677889900112233", "7788990011223344", "8899001122334455" } },
                { "Org8", new List<string> { "9900112233445566", "0011223344556677" } },
                { "Org9", new List<string> { "1122334455667788", "2233445566778899" } }
            };

            // Faker configuration for the "items" table
            var itemFaker = new Faker<Item>()
                .RuleFor(i => i.ItemId, f => f.Random.AlphaNumeric(5))
                .RuleFor(i => i.ItemName, f => f.Commerce.ProductName())
                .RuleFor(i => i.Quantity, f => f.Random.Int(1, 500))
                .RuleFor(i => i.Location, f => $"{f.Random.Char('A', 'Z')}{f.Random.Int(1, 25)}")
                .RuleFor(i => i.AlertLevel, f => f.Random.Int(1, 10))
                .RuleFor(i => i.OrganizationName, f => f.PickRandom(organizations.Keys.ToList())) // Random organization
                .RuleFor(i => i.DatabaseId, (f, item) =>
                {
                    // Pick a random database ID based on the already assigned OrganizationName
                    var dbIds = organizations[item.OrganizationName];
                    return f.PickRandom(dbIds);
                })
                .RuleFor(i => i.Databasename, (f, item) =>
                {
                    var dbIds = organizations[item.OrganizationName];
                    int index = dbIds.IndexOf(item.DatabaseId); // Get index of DatabaseId
                    return $"DB{index}"; // Format as "DB0", "DB1", etc.
                });


            // Generate and insert 50 mock items
            for (int i = 0; i < 5000; i++)
            {
                var item = itemFaker.Generate();
                await client.InsertDataAsync("items", item);
            }

            Console.WriteLine("Items table populated successfully.");
        }
    }
}
