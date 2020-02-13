# ArtNet 3 .NET
Simple ArtNet 3 Implementation for .NET in C# to send and receive dmx packages.

## Info
This code was created for teaching purposes and not to be used in productive applications. The protocol is not fully implemented and there are of course bugs. Please be aware when using this code in your application!

## Example

```csharp
Console.WriteLine("ArtDotNet Client");
var controller = new ArtNetController();
controller.Address = IPAddress.Loopback;

controller.DmxPacketReceived += (s, p) =>
{
	Console.WriteLine("DMX Packet received " + p.Length);
};

controller.Start();

Console.ReadKey(true);

controller.Stop();
```
