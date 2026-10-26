
using System.Net.Http.Json;
using BlazorChat.Dto.Requests;
using BlazorChat.Dto.Results;

namespace BlazorChat.Sdk
{
    public class ChatChannelService(IHttpClientFactory httpClientFactory)
    {
        public async Task<IList<ChatChannelResult>> Find()
        {
            var httpClient = httpClientFactory.CreateClient("TalkApi");
            var route = "/api/chat-channels";

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var channels = await httpResponse.Content.ReadFromJsonAsync<IList<ChatChannelResult>>();

            return channels ?? new List<ChatChannelResult>();
        }

        public async Task<ChatChannelResult?> Create(ChatChannelRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("TalkApi");
            var route = "/api/chat-channels";

            var httpResponse = await httpClient.PostAsJsonAsync(route, request);

            httpResponse.EnsureSuccessStatusCode();

            var channel = await httpResponse.Content.ReadFromJsonAsync<ChatChannelResult>();

            return channel;
        }
    }
}
