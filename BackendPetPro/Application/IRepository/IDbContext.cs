using System.Text.Json.Nodes;

namespace BackendPetPro.Application.IRepository
{
    public interface IDbContext
    {
        public void connect(string connectString);
        public void close();
        public void command(string command, Dictionary<string, object> parameters);
        List<JsonObject> read(string command, Dictionary<string, object> parameters);
    }
}
