using LineNotifySharp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LineNotifySharp;
public class LineNotifyClient : ILineNotifyClient
{
    private const string _url = "https://notify-api.line.me";
    private readonly HttpClient _client;
    public LineNotifyClient(string accessToken, string uri = _url)
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    }
    public async Task SendTextMessageAsync(string text)
    {
        await SendMessageAsync(new MessageObject(text));
    }
    public async Task SendMessageAsync(MessageObject messageObject)
    {
        var dic = new Dictionary<string, string>();
        dic.Add("message", messageObject.Message);
        if (messageObject.ImageThumbnail != null) dic.Add("imageThumbnail", messageObject.ImageThumbnail);
        if (messageObject.ImageFullsize != null) dic.Add("imageFullsize", messageObject.ImageFullsize);
        if (messageObject.ImageFile != null) dic.Add("imageFile", messageObject.ImageFile);
        if (messageObject.StickerPackageId != null) dic.Add("stickerPackageId", messageObject.StickerPackageId);
        if (messageObject.StickerId != null) dic.Add("stickerId", messageObject.StickerId);
        dic.Add("notificationDisabled", messageObject.NotificationDisabled.ToString());

        var content = new FormUrlEncodedContent(dic);
        await _client.PostAsync($"{_url}/api/notify", content).ConfigureAwait(false);
    }
    public async Task<bool> IsValidAccessTokenAsync()
    {
        var res = await _client.GetAsync($"{_url}/api/status").ConfigureAwait(false);
        if (res.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<bool> RevokeAsync()
    {
        var res = await _client.PostAsync($"{_url}/api/revoke", null).ConfigureAwait(false);
        if (res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //AccessToken has been disabled.
            return true;
        }
        else if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            //AccessToken is already invalid
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<string> GetAccessTokenAsync(string code, string redirectUri, string clientId, string clientSecret)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", code },
            { "redirect_uri", redirectUri},
            { "client_id", clientId },
            { "client_secret", clientSecret }
        });
        string res = await _client.PostAsync($"{_url}/oauth/token", content).Result.Content.ReadAsStringAsync() ?? throw new ArgumentNullException();
        var o = JsonConvert.DeserializeObject<AccessTokenObject>(res) ?? throw new ArgumentNullException();
        return o.AccessToken;
    }
}