using LineNotifySharp.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LineNoitifySharp;
public class LineNotifyClient
{
    private const string _url = "https://notify-api.line.me";
    private readonly HttpClient _client;
    public LineNotifyClient(string accessToken, string uri = _url)
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    }
    public async Task SendMessageAsync(MessageObject messageObject)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "message", messageObject.Message },
            { "imageThumbnail", messageObject.ImageThumbnail },
            { "imageFullsize", messageObject.ImageFullsize },
            { "imageFile", messageObject.ImageFile },
            { "stickerPackageId", messageObject.StickerPackageId.ToString() },
            { "stickerId", messageObject.StickerId.ToString() },
            { "notificationDisabled", messageObject.NotificationDisabled.ToString() },
        });
        await _client.PostAsync($"{_url}/api/notify",content).ConfigureAwait(false);
    }
}