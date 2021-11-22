using LineNotifySharp.Model;
using System.Threading.Tasks;

namespace LineNotifySharp;
public interface ILineNotifyClient
{
    Task SendMessageAsync(MessageObject messageObject);
    Task<bool> IsValidAccessTokenAsync();
    Task<bool> RevokeAsync();
    Task<string> GetAccessTokenAsync(string code, string redirectUri, string clientId, string clientSecret);
    Task SendTextMessageAsync(string text);
}