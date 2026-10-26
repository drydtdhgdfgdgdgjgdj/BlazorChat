
using System.Net.Http.Json;
using BlazorChat.Dto.Requests;
using BlazorChat.Dto.Results;

namespace BlazorChat.Sdk
{
    public class ChatMessageService(IHttpClientFactory httpClientFactory)
    {
        public async Task<IList<ChatMessageResult>> Find()
        {
            var httpClient = httpClientFactory.CreateClient("TalkApi");
            var route = "/api/chat-messages";

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var messages = await httpResponse.Content.ReadFromJsonAsync<IList<ChatMessageResult>>();

            return messages ?? new List<ChatMessageResult>();
        }

        public async Task<ChatMessageResult?> Create(ChatMessageRequest request)
        {
            var httpClient = httpClientFactory.CreateClient("TalkApi");
            var route = "/api/chat-messages";

            var httpResponse = await httpClient.PostAsJsonAsync(route, request);

            httpResponse.EnsureSuccessStatusCode();

            var message = await httpResponse.Content.ReadFromJsonAsync<ChatMessageResult>();

            return message;
        }
    }
}
