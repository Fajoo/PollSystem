using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Desktop.Models;
using Microsoft.Extensions.Configuration;

namespace Desktop.Services;

public class SimpleHttpClient
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public SimpleHttpClient(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
        //!ToDo Get token
        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _configuration["token"]);
    }

    public async Task<ApiResult<T>> GetAsync<T>(string url)
    {
        T res = default;

        var response = await _client.GetAsync(_client.BaseAddress + url)
            .ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
            res = await response.Content.ReadAsAsync<T>();

        return new ApiResult<T>
        {
            Obj = res,
            Code = response.StatusCode
        };
    }

    public async Task<HttpStatusCode> DeleteAsync(string url)
    {
        var response = await _client.DeleteAsync(_client.BaseAddress + url)
            .ConfigureAwait(false);
        return response.StatusCode;
    }

    public async Task<HttpStatusCode> UpdateProductAsync<T>(string url, T obj)
    {
        var response = await _client.PutAsJsonAsync(_client.BaseAddress + url, obj)
            .ConfigureAwait(false);
        return response.StatusCode;
    }

    public async Task<ApiResult<Guid>> CreateAsync<T>(string url, T obj)
    {
        var res = Guid.Empty;

        var response = await _client.PostAsJsonAsync(_client.BaseAddress + url, obj)
            .ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
            res = await response.Content.ReadAsAsync<Guid>();

        return new ApiResult<Guid>
        {
            Obj = res,
            Code = response.StatusCode
        };
    }
}