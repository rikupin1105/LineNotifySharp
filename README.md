# LineNotifySharp
 
## Installation
Using [Nuget](https://www.nuget.org/packages/LineNotifySharp/)
```
PM> Install-Package LineNotifySharp -Version 1.0.1
> dotnet add package LineNotifySharp --version 1.0.1
```

## How to Use

```cs
using LineNoitifySharp;
using LineNotifySharp.Model;

var client = new LineNotifyClient("ACCESS_TOKEN");
await client.SendMessageAsync(new MessageObject("HelloWorld"));
```
