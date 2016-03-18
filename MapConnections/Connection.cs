using System.Net.NetworkInformation;

namespace MapConnections
{
    public sealed class Connection : IConnection
    {

        public Connection(TcpConnectionInformation info)
        {
            this.RemoteAddress = info.RemoteEndPoint.Address;
            this.LocalAddress = info.LocalEndPoint.Address;
            this.LocalPort = info.LocalEndPoint.Port;
            this.RemotePort = info.RemoteEndPoint.Port;
            this.State = info.State;
            double? a, b;
            GeoDatabase.GetPosition(RemoteAddress.ToString(),out a,out b);
            this.Longitude = a;
            this.Latitude = b;
        }

        public System.Net.IPAddress RemoteAddress { get; }
        public System.Net.IPAddress LocalAddress { get; }
        public int LocalPort { get; }
        public int RemotePort { get; }
        public TcpState State { get; }

        public double? Longitude { get; }
        public double? Latitude { get; }
    }
}
