using System.Threading.Tasks;

namespace SupabaseMockData
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Replace with your Supabase details
            var supabaseUrl = "https://hvqrsutsvovnizmipksd.supabase.co";
            var apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imh2cXJzdXRzdm92bml6bWlwa3NkIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mzc0MjMwNjAsImV4cCI6MjA1Mjk5OTA2MH0.Dr0fvzfUNaH3AdhGhsOP11kFW5t4KFL999Oetog0wWY";

            var client = new SupabaseClient(supabaseUrl, apiKey);

            // Populate mock data for the "items" table
            await MockDataGenerator.PopulateItems(client);

            Console.WriteLine("Supabase items table populated with mock data.");
        }
    }
}
