using System.Collections.ObjectModel;

namespace MapConnections
{
    interface IListConnections
    {
        ObservableCollection<Connection> ActiveConnections { get; }
        void PopulateList();
    }
}
