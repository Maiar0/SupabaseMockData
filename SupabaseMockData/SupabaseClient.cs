using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SupabaseMockData
{
    public class SupabaseClient
    {
        private readonly string _supabaseUrl;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public SupabaseClient(string supabaseUrl, string apiKey)
        {
            _supabaseUrl = supabaseUrl;
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("apikey", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task InsertDataAsync(string tableName, object data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_supabaseUrl}/rest/v1/{tableName}", data);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Data successfully inserted into {tableName}.");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error inserting data into {tableName}: {response.StatusCode}, {error}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }
    }
}
