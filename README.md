# ArtNet3DotNet
ArtNet 3 Implementation for .NET in C#

## Example

```
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