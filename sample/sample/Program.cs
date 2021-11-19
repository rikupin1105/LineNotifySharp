using LineNoitifySharp;
using LineNotifySharp.Model;

var client = new LineNotifyClient("ACCESS_TOKEN");
await client.SendMessageAsync(new MessageObject("HelloWorld"));