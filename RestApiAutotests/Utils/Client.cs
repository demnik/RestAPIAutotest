using Newtonsoft.Json.Linq;
using RestSharp;

namespace RestApiAutotests.Utils;

public static class Client
{
    private const string BaseUrl = "https://fakerestapi.azurewebsites.net";

    public static List<Dictionary<string, object>> Get(string resource)
    {
        using var client = new RestClient(BaseUrl);
        var request = new RestRequest(resource);
        var response = client.Execute(request);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Запрос выполнен неудачно. Код ошибки {response.StatusCode}. {response.StatusDescription}");
        
        return JArray.Parse(response.Content)
        .Select(item => ((JObject)item).ToObject<Dictionary<string, object>>())
        .ToList();
    }
}
