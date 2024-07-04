using BackendPetPro.Application;
using BackendPetPro.Application.IRepository;
using Npgsql;
using System.Text.Json.Nodes;

namespace BackendPetPro.Infra.Repository
{
    public class PGSQLContext : IDbContext
    {
        private NpgsqlConnection _conn;
        public void connect(string connectString)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectString);
            _conn = conn;
            _conn.Open();
         } 
        public void close()
        {
            _conn.Close();
        }

        public void command(string command, Dictionary<string, object> parameters)
        {
            using(NpgsqlCommand cmd = new NpgsqlCommand(command, _conn))
            {
              foreach(var param in parameters) 
              {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
              }
              cmd.ExecuteNonQuery();
            }
        }

        public List<JsonObject> read(string command, Dictionary<string, object> parameters)
        {
            List<JsonObject> resultOfQuery = new List<JsonObject> ();
            using (NpgsqlCommand cmd = new NpgsqlCommand(command, _conn))
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JsonObject lineOfResult = new JsonObject();
                        for(int i = 0; i < reader.FieldCount; i++)
                        {
                            lineOfResult.Add(reader.GetName(i), JsonValue.Create(reader.GetValue(i)));
                        }
                        resultOfQuery.Add(lineOfResult);
                    }
                }
            }
            return resultOfQuery;
        }
    }
}
