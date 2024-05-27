using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

public class AuthService
{
    private readonly HttpClient _client;
    public AuthService()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri("http://172.30.74.244:5000")
        };
    }
    public async Task<bool> Register(string name, string mail, string password)
    {
        var data = new { name, mail, password };
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/auth/register", content);

        return response.IsSuccessStatusCode;
    }

    public async Task<string> Login(string mail, string password)
    {
        var data = new { mail, password };
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/auth/login", content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<Dictionary<string, string>>(result)["access_token"];
            await SecureStorage.SetAsync("jwt_token", token);
            return token;
        }

        return null;
    }
}
