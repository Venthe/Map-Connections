using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace MapConnections
{
    public sealed class ListConnections : IListConnections
    {
        public ObservableCollection<Connection> ActiveConnections { get; }

        public ListConnections()
        {
            ActiveConnections = new ObservableCollection<Connection>();
        }

        private readonly object _lockVar = new object();
        public void PopulateList()
        {
            lock (_lockVar)
            {
                ActiveConnections.Clear();
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
                foreach (TcpConnectionInformation c in connections)
                {
                    //TODO: Get local IP address and WAN ip address and remove it from the list of results. Currently used method is insufficient
                    if (c.LocalEndPoint.ToString().Contains("::1") || c.RemoteEndPoint.ToString().Contains("::1"))
                        continue;
                    if (c.LocalEndPoint.ToString().Contains("127.0.0.1") &&
                        c.RemoteEndPoint.ToString().Equals(c.RemoteEndPoint.ToString())) continue;

                    ActiveConnections.Add(new Connection(c));
                }
            }
        }
    }
}
