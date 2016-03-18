using System.Net.NetworkInformation;

namespace MapConnections
{
    public interface IConnection
    {
        System.Net.IPAddress RemoteAddress { get; }
        System.Net.IPAddress LocalAddress { get; }
        int LocalPort { get; }
        int RemotePort { get; }
        double? Longitude { get; }
        double? Latitude { get; }
        TcpState State { get; }
    }
}
