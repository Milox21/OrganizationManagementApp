using System.Text.Json;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models.Contexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OMP_API.Services
{
    public class SeedingService
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "User", "Manager" };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public static async Task RefreshCoutnriesAsync()
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync("https://restcountries.com/v3.1/all");

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"API request failed: {response.StatusCode}");
                        return;
                    }

                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var apiCountries = JsonSerializer.Deserialize<ApiCountry[]>(content, options);

                    using (var dbContext = new DatabaseContext())
                    {
                        dbContext.Countries.RemoveRange(dbContext.Countries);
                        await dbContext.SaveChangesAsync();

                        foreach (var apiCountry in apiCountries)
                        {
                            dbContext.Countries.Add(new Models.Country
                            {
                                Name = apiCountry.Name.Common,
                                Description = apiCountry.Region,
                                CreationDate = DateTime.Now,
                                IsDeleted = false,
                            });
                        }

                        await dbContext.SaveChangesAsync();
                        Console.WriteLine($"Successfully added {apiCountries.Length} countries");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing countries: {ex.Message}");
            }
        }

        public static async Task RefreshCurrenciesAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://v6.exchangerate-api.com/v6/aef4a7e9dc30374d13ee9273/latest/USD");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API request failed: {response.StatusCode}");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var currencyData = JsonSerializer.Deserialize<ExchangeRateResponse>(content, options);

                // Only keep the desired currencies
                var targetCurrencies = new[] { "USD", "CNY", "JPY", "PLN", "EUR" };

                using var dbContext = new DatabaseContext();

                foreach (var code in targetCurrencies)
                {
                    if (!currencyData.Conversion_Rates.TryGetValue(code, out var rate))
                        continue;

                    var existingCurrency = dbContext.Currencies.FirstOrDefault(c => c.Code == code);

                    if (existingCurrency != null)
                    {
                        existingCurrency.ExchangeRateToDollar = rate;
                        existingCurrency.EditDate = DateTime.Now;
                        existingCurrency.IsDeleted = false;
                    }
                    else
                    {
                        dbContext.Currencies.Add(new Models.Currency
                        {
                            Code = code,
                            ExchangeRateToDollar = rate,
                            CreationDate = DateTime.Now,
                            IsDeleted = false
                        });
                    }
                }

                await dbContext.SaveChangesAsync();
                Console.WriteLine("Successfully updated selected currencies.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing currencies: {ex.Message}");
            }
        }
    }

    // Helper class for API response
    public class ApiCountry
    {
        public CountryName Name { get; set; }
        public string Region { get; set; } // Continent information
    }

    public class CountryName
    {
        public string Common { get; set; }
    }

    public class ExchangeRateResponse
    {
        public string Result { get; set; }
        public Dictionary<string, decimal> Conversion_Rates { get; set; }
    }
}
